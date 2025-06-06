using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1 : QueryBasis<DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERT_VGAP
            , NUM_CLIENTE
            INTO :H-NUMEROUT-NUM-CERT-VGAP
            , :H-NUMEROUT-NUM-CLIENTE
            FROM SEGUROS.NUMERO_OUTROS
            WHERE 1 = 1
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERT_VGAP
											, NUM_CLIENTE
											FROM SEGUROS.NUMERO_OUTROS
											WHERE 1 = 1";

            return query;
        }
        public string H_NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string H_NUMEROUT_NUM_CLIENTE { get; set; }

        public static DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1 Execute(DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1 dB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1)
        {
            var ths = dB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB016_ACESSA_NUMEROS_OUTROS_DB_SELECT_1_Query1();
            var i = 0;
            dta.H_NUMEROUT_NUM_CERT_VGAP = result[i++].Value?.ToString();
            dta.H_NUMEROUT_NUM_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}