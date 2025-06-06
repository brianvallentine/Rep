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
    public class R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1 : QueryBasis<R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPERACAO
            INTO :SINCREIN-COD-OPERACAO
            FROM SEGUROS.SINISTRO_CRED_INT
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_OPERACAO
											FROM SEGUROS.SINISTRO_CRED_INT
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINCREIN_COD_OPERACAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1 Execute(R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1 r4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1)
        {
            var ths = r4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINCREIN_COD_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}