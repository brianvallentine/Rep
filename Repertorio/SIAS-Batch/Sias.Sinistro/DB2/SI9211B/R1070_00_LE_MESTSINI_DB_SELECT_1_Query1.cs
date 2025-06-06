using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1070_00_LE_MESTSINI_DB_SELECT_1_Query1 : QueryBasis<R1070_00_LE_MESTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            , OCORR_HISTORICO
            INTO :SINISMES-COD-PRODUTO
            , :SINISMES-OCORR-HISTORICO
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											, OCORR_HISTORICO
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string SINISMES_OCORR_HISTORICO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }

        public static R1070_00_LE_MESTSINI_DB_SELECT_1_Query1 Execute(R1070_00_LE_MESTSINI_DB_SELECT_1_Query1 r1070_00_LE_MESTSINI_DB_SELECT_1_Query1)
        {
            var ths = r1070_00_LE_MESTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1070_00_LE_MESTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1070_00_LE_MESTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISMES_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}