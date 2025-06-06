using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1 : QueryBasis<R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA,
            NUM_CONTRATO,
            DV_CONTRATO
            INTO :SINIPENH-COD-AGENCIA,
            :SINIPENH-NUM-CONTRATO,
            :SINIPENH-DV-CONTRATO
            FROM SEGUROS.SINI_PENHOR01
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
							,
											NUM_CONTRATO
							,
											DV_CONTRATO
											FROM SEGUROS.SINI_PENHOR01
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINIPENH_COD_AGENCIA { get; set; }
        public string SINIPENH_NUM_CONTRATO { get; set; }
        public string SINIPENH_DV_CONTRATO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1 Execute(R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1 r960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1)
        {
            var ths = r960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIPENH_COD_AGENCIA = result[i++].Value?.ToString();
            dta.SINIPENH_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.SINIPENH_DV_CONTRATO = result[i++].Value?.ToString();
            return dta;
        }

    }
}