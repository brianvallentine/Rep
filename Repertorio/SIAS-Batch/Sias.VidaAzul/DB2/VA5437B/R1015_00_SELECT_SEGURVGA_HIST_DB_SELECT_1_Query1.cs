using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 : QueryBasis<R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(DATA_OPERACAO),
            :SEGURVGA-DATA-INIVIGENCIA)
            INTO :SEGURVGA-DATA-INIVIGENCIA
            FROM SEGUROS.SEGURADOSVGAP_HIST
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND COD_OPERACAO = 101
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(DATA_OPERACAO)
							,
											'{this.SEGURVGA_DATA_INIVIGENCIA}')
											FROM SEGUROS.SEGURADOSVGAP_HIST
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND COD_OPERACAO = 101
											WITH UR";

            return query;
        }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }

        public static R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 Execute(R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 r1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1)
        {
            var ths = r1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}