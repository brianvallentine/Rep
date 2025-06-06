using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1652B
{
    public class R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 : QueryBasis<R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PERI_FATURAMENTO,
            TIPO_FATURAMENTO
            INTO :SUBGVGAP-PERI-FATURAMENTO,
            :SUBGVGAP-TIPO-FATURAMENTO
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PERI_FATURAMENTO
							,
											TIPO_FATURAMENTO
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string SUBGVGAP_TIPO_FATURAMENTO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 Execute(R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 r2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_PERI_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_FATURAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}