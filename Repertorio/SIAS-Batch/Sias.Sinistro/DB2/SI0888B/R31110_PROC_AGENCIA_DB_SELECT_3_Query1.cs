using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0888B
{
    public class R31110_PROC_AGENCIA_DB_SELECT_3_Query1 : QueryBasis<R31110_PROC_AGENCIA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_AGENCIA
            INTO
            :SINIPENH-COD-AGENCIA
            FROM SEGUROS.SINI_PENHOR01
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_AGENCIA
											FROM SEGUROS.SINI_PENHOR01
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINIPENH_COD_AGENCIA { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R31110_PROC_AGENCIA_DB_SELECT_3_Query1 Execute(R31110_PROC_AGENCIA_DB_SELECT_3_Query1 r31110_PROC_AGENCIA_DB_SELECT_3_Query1)
        {
            var ths = r31110_PROC_AGENCIA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R31110_PROC_AGENCIA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R31110_PROC_AGENCIA_DB_SELECT_3_Query1();
            var i = 0;
            dta.SINIPENH_COD_AGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}