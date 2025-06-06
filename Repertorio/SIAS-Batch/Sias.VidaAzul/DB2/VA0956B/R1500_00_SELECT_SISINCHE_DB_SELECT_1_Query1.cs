using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0956B
{
    public class R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUM_CHEQUE_INTERNO
            INTO :SISINCHE-NUM-CHEQUE-INTERNO
            FROM SEGUROS.SI_SINI_CHEQUE
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_CHEQUE_INTERNO
											FROM SEGUROS.SI_SINI_CHEQUE
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											WITH UR";

            return query;
        }
        public string SISINCHE_NUM_CHEQUE_INTERNO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1 r1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_SISINCHE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISINCHE_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            return dta;
        }

    }
}