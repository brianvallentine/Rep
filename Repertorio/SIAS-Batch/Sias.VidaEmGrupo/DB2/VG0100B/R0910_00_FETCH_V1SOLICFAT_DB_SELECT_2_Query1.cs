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
    public class R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1 : QueryBasis<R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(NUM_TITULO,0)
            INTO :NUM-TITULO
            FROM SEGUROS.VG_SOLICITA_FATURA
            WHERE NUM_APOLICE = :V1SOLF-NUM-APOL
            AND COD_SUBGRUPO = :V1SOLF-COD-SUBG
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(NUM_TITULO
							,0)
											FROM SEGUROS.VG_SOLICITA_FATURA
											WHERE NUM_APOLICE = '{this.V1SOLF_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.V1SOLF_COD_SUBG}'";

            return query;
        }
        public string NUM_TITULO { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }
        public string V1SOLF_COD_SUBG { get; set; }

        public static R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1 Execute(R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1 r0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1)
        {
            var ths = r0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0910_00_FETCH_V1SOLICFAT_DB_SELECT_2_Query1();
            var i = 0;
            dta.NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}