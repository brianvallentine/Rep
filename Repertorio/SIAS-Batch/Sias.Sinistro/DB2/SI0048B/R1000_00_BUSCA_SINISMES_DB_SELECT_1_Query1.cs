using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0048B
{
    public class R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1 : QueryBasis<R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO,
            NUM_APOL_SINISTRO,
            DATA_COMUNICADO,
            COD_CAUSA,
            RAMO
            INTO :SINISMES-COD-PRODUTO,
            :SINISMES-NUM-APOL-SINISTRO,
            :SINISMES-DATA-COMUNICADO,
            :SINISMES-COD-CAUSA,
            :SINISMES-RAMO
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
							,
											NUM_APOL_SINISTRO
							,
											DATA_COMUNICADO
							,
											COD_CAUSA
							,
											RAMO
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_DATA_COMUNICADO { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1 Execute(R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1 r1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}