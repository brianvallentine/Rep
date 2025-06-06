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
    public class R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 : QueryBasis<R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_REFERENCIA
            INTO :V1FATC-DATA-REFER
            FROM SEGUROS.V1FATURCONT
            WHERE NUM_APOLICE = :W1SOLF-NUM-APOL
            AND COD_SUBGRUPO = :W1SOLF-COD-SUBG
            AND DATA_ULT_FATURAMEN = :V1SIST-DTMOVABE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_REFERENCIA
											FROM SEGUROS.V1FATURCONT
											WHERE NUM_APOLICE = '{this.W1SOLF_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.W1SOLF_COD_SUBG}'
											AND DATA_ULT_FATURAMEN = '{this.V1SIST_DTMOVABE}'";

            return query;
        }
        public string V1FATC_DATA_REFER { get; set; }
        public string W1SOLF_NUM_APOL { get; set; }
        public string W1SOLF_COD_SUBG { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 Execute(R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 r5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1)
        {
            var ths = r5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5400_00_SELECT_V1FATURCONT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FATC_DATA_REFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}