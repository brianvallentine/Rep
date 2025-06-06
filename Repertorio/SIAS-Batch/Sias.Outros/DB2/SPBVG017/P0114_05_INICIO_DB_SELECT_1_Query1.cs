using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG017
{
    public class P0114_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0114_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VG142.COD_PRODUTO
            INTO :VG142-COD-PRODUTO
            FROM SEGUROS.VG_PRODUTO_REGRA_DPS VG142
            WHERE VG142.SEQ_PRODUTO_DPS = :VG142-SEQ-PRODUTO-DPS
            AND DATE(:SISTEMAS-DATA-MOV-ABERTO)
            BETWEEN DTA_INI_VIGENCIA
            AND DTA_FIM_VIGENCIA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VG142.COD_PRODUTO
											FROM SEGUROS.VG_PRODUTO_REGRA_DPS VG142
											WHERE VG142.SEQ_PRODUTO_DPS = '{this.VG142_SEQ_PRODUTO_DPS}'
											AND DATE('{this.SISTEMAS_DATA_MOV_ABERTO}')
											BETWEEN DTA_INI_VIGENCIA
											AND DTA_FIM_VIGENCIA
											WITH UR";

            return query;
        }
        public string VG142_COD_PRODUTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string VG142_SEQ_PRODUTO_DPS { get; set; }

        public static P0114_05_INICIO_DB_SELECT_1_Query1 Execute(P0114_05_INICIO_DB_SELECT_1_Query1 p0114_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0114_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0114_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0114_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG142_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}