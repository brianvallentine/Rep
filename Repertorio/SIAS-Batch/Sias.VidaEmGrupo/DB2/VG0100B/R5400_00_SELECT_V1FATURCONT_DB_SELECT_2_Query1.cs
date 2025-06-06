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
    public class R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1 : QueryBasis<R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_FATURA),0)
            INTO :V9SOLF-NUM-FAT
            FROM SEGUROS.V1SOLICITAFAT
            WHERE NUM_APOLICE = :W1SOLF-NUM-APOL
            AND COD_SUBGRUPO = :W1SOLF-COD-SUBG
            AND FONTE IS NULL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_FATURA)
							,0)
											FROM SEGUROS.V1SOLICITAFAT
											WHERE NUM_APOLICE = '{this.W1SOLF_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.W1SOLF_COD_SUBG}'
											AND FONTE IS NULL";

            return query;
        }
        public string V9SOLF_NUM_FAT { get; set; }
        public string W1SOLF_NUM_APOL { get; set; }
        public string W1SOLF_COD_SUBG { get; set; }

        public static R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1 Execute(R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1 r5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1)
        {
            var ths = r5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5400_00_SELECT_V1FATURCONT_DB_SELECT_2_Query1();
            var i = 0;
            dta.V9SOLF_NUM_FAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}