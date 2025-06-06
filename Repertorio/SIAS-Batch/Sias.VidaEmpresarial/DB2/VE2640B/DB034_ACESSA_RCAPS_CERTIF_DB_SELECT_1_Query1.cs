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
    public class DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1 : QueryBasis<DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            NUM_RCAP,
            VAL_RCAP,
            NUM_TITULO
            INTO :RCAPS-COD-FONTE,
            :RCAPS-NUM-RCAP,
            :RCAPS-VAL-RCAP,
            :RCAPS-NUM-TITULO
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO
            AND COD_OPERACAO BETWEEN 100 AND 199
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											NUM_RCAP
							,
											VAL_RCAP
							,
											NUM_TITULO
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO = '{this.RCAPS_NUM_CERTIFICADO}'
											AND COD_OPERACAO BETWEEN 100 AND 199";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_NUM_TITULO { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }

        public static DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1 Execute(DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1 dB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1)
        {
            var ths = dB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB034_ACESSA_RCAPS_CERTIF_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_NUM_TITULO = result[i++].Value?.ToString();
            return dta;
        }

    }
}