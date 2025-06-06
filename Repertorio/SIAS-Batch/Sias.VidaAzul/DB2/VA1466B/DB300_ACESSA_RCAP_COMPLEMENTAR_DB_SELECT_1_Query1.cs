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
    public class DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1 : QueryBasis<DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_RCAP
            INTO :RCAPCOMP-DATA-RCAP
            FROM SEGUROS.RCAP_COMPLEMENTAR
            WHERE COD_FONTE = :RCAPCOMP-COD-FONTE
            AND NUM_RCAP = :RCAPCOMP-NUM-RCAP
            AND NUM_RCAP_COMPLEMEN = 0
            AND SIT_REGISTRO = '0'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_RCAP
											FROM SEGUROS.RCAP_COMPLEMENTAR
											WHERE COD_FONTE = '{this.RCAPCOMP_COD_FONTE}'
											AND NUM_RCAP = '{this.RCAPCOMP_NUM_RCAP}'
											AND NUM_RCAP_COMPLEMEN = 0
											AND SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string RCAPCOMP_DATA_RCAP { get; set; }
        public string RCAPCOMP_COD_FONTE { get; set; }
        public string RCAPCOMP_NUM_RCAP { get; set; }

        public static DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1 Execute(DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1 dB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1)
        {
            var ths = dB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB300_ACESSA_RCAP_COMPLEMENTAR_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPCOMP_DATA_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}