using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0105B
{
    public class R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 : QueryBasis<R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.DATA_REFERENCIA,
            A.DATA_REFERENCIA + B.PERI_FATURAMENTO MONTH
            - 1 DAY
            INTO :V1FATC-DATA-REFER,
            :DATA-TERVIG
            FROM SEGUROS.V1FATURCONT A,
            SEGUROS.V1SUBGRUPO B
            WHERE A.NUM_APOLICE = B.NUM_APOLICE
            AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
            AND A.NUM_APOLICE = :V1SOLF-NUM-APOL
            AND A.COD_SUBGRUPO = :V1SOLF-COD-SUBG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.DATA_REFERENCIA
							,
											A.DATA_REFERENCIA + B.PERI_FATURAMENTO MONTH
											- 1 DAY
											FROM SEGUROS.V1FATURCONT A
							,
											SEGUROS.V1SUBGRUPO B
											WHERE A.NUM_APOLICE = B.NUM_APOLICE
											AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
											AND A.NUM_APOLICE = '{this.V1SOLF_NUM_APOL}'
											AND A.COD_SUBGRUPO = '{this.V1SOLF_COD_SUBG}'";

            return query;
        }
        public string V1FATC_DATA_REFER { get; set; }
        public string DATA_TERVIG { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }
        public string V1SOLF_COD_SUBG { get; set; }

        public static R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 Execute(R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 r2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1)
        {
            var ths = r2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2315_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FATC_DATA_REFER = result[i++].Value?.ToString();
            dta.DATA_TERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}