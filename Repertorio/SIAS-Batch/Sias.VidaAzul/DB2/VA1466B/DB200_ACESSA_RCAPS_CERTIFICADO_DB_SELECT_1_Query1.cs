using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1466B
{
    public class DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1 : QueryBasis<DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE
            , NUM_RCAP
            INTO :RCAPS-COD-FONTE
            , :RCAPS-NUM-RCAP
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
											, NUM_RCAP
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO = '{this.RCAPS_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }

        public static DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1 Execute(DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1 dB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1)
        {
            var ths = dB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB200_ACESSA_RCAPS_CERTIFICADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}