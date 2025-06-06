using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0869B
{
    public class R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1 : QueryBasis<R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_OPERACAO
            INTO :GEOPERAC-DES-OPERACAO
            FROM SEGUROS.GE_OPERACAO
            WHERE COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND IDE_SISTEMA = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DES_OPERACAO
											FROM SEGUROS.GE_OPERACAO
											WHERE COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND IDE_SISTEMA = 'SI'";

            return query;
        }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1 Execute(R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1 r230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1)
        {
            var ths = r230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}