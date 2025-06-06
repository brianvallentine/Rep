using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0853B
{
    public class R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1 : QueryBasis<R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CAUSA
            INTO :SINIMPSE-COD-CAUSA
            FROM SEGUROS.SINISTRO_IMP_SEG
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINIMPSE-OCORR-HISTORICO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_CAUSA
											FROM SEGUROS.SINISTRO_IMP_SEG
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINIMPSE_OCORR_HISTORICO}'";

            return query;
        }
        public string SINIMPSE_COD_CAUSA { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }
        public string SINIMPSE_OCORR_HISTORICO { get; set; }

        public static R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1 Execute(R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1 r2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1)
        {
            var ths = r2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_CAUSA_ANTERIOR_DB_SELECT_2_Query1();
            var i = 0;
            dta.SINIMPSE_COD_CAUSA = result[i++].Value?.ToString();
            return dta;
        }

    }
}