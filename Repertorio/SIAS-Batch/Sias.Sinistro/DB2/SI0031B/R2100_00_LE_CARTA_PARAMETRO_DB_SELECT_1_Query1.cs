using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0031B
{
    public class R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1 : QueryBasis<R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT PRAZO_REITERACAO
            INTO :GECARPAR-PRAZO-REITERACAO
            FROM SEGUROS.GE_CARTA_PARAMETRO
            WHERE COD_TIPO_CARTA = :SIDOCPAR-COD-TIPO-CARTA
            AND COD_PRODUTO = :H-SIDOCACO-COD-PRODUTO
            AND COD_CLIENTE = :SIMOVSIN-COD-ESTIPULANTE
            AND DATA_INIVIG_CARPAR <= :SISTEMAS-DATA-MOV-ABERTO
            AND DATA_TERVIG_CARPAR >= :SISTEMAS-DATA-MOV-ABERTO
            ORDER BY PRAZO_REITERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT PRAZO_REITERACAO
											FROM SEGUROS.GE_CARTA_PARAMETRO
											WHERE COD_TIPO_CARTA = '{this.SIDOCPAR_COD_TIPO_CARTA}'
											AND COD_PRODUTO = '{this.H_SIDOCACO_COD_PRODUTO}'
											AND COD_CLIENTE = '{this.SIMOVSIN_COD_ESTIPULANTE}'
											AND DATA_INIVIG_CARPAR <= '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND DATA_TERVIG_CARPAR >= '{this.SISTEMAS_DATA_MOV_ABERTO}'
											ORDER BY PRAZO_REITERACAO";

            return query;
        }
        public string GECARPAR_PRAZO_REITERACAO { get; set; }
        public string SIMOVSIN_COD_ESTIPULANTE { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SIDOCPAR_COD_TIPO_CARTA { get; set; }
        public string H_SIDOCACO_COD_PRODUTO { get; set; }

        public static R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1 Execute(R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1 r2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GECARPAR_PRAZO_REITERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}