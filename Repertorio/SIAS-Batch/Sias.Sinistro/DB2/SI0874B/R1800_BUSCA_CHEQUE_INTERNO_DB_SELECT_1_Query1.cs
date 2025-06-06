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
    public class R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1 : QueryBasis<R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CHEQUE_INTERNO
            INTO :SISINCHE-NUM-CHEQUE-INTERNO
            FROM SEGUROS.SI_SINI_CHEQUE
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CHEQUE_INTERNO
											FROM SEGUROS.SI_SINI_CHEQUE
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											WITH UR";

            return query;
        }
        public string SISINCHE_NUM_CHEQUE_INTERNO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1 Execute(R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1 r1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1)
        {
            var ths = r1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISINCHE_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            return dta;
        }

    }
}