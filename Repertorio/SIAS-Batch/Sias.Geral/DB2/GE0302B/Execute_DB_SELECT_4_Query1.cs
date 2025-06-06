using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0302B
{
    public class Execute_DB_SELECT_4_Query1 : QueryBasis<Execute_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOL_SINISTRO
            INTO :SINISHIS-NUM-APOL-SINISTRO
            FROM SEGUROS.SI_SINI_CHEQUE
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND COD_OPERACAO = :SINISHIS-COD-OPERACAO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOL_SINISTRO
											FROM SEGUROS.SI_SINI_CHEQUE
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'";

            return query;
        }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static Execute_DB_SELECT_4_Query1 Execute(Execute_DB_SELECT_4_Query1 execute_DB_SELECT_4_Query1)
        {
            var ths = execute_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override Execute_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new Execute_DB_SELECT_4_Query1();
            var i = 0;
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}