using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0502S
{
    public class R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1 : QueryBasis<R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(RAMO, 0),
            VALUE(COD_PRODUTO, 0),
            OCORR_HISTORICO
            INTO :SINISMES-RAMO,
            :SINISMES-COD-PRODUTO,
            :SINISMES-OCORR-HISTORICO
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(RAMO
							, 0)
							,
											VALUE(COD_PRODUTO
							, 0)
							,
											OCORR_HISTORICO
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SINISMES_OCORR_HISTORICO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1 Execute(R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1 r1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISMES_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}