using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1 : QueryBasis<R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_FATURAMENTO
            INTO :SUBGVGAP-PERI-FATURAMENTO
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_FATURAMENTO
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'";

            return query;
        }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1 Execute(R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1 r2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_SELECT_PERI_FATUR_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_PERI_FATURAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}