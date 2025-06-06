using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1 : QueryBasis<R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT INFORMACAO_COMPL
            INTO :PRPFIDCO-INFORM-COMPLEM
            FROM SEGUROS.PROP_FIDELIZ_COMP
            WHERE NUM_IDENTIFICACAO =
            :PRPFIDEL-NUM-IDENTIFICA
            AND IND_TP_INFORMACAO = '1'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT INFORMACAO_COMPL
											FROM SEGUROS.PROP_FIDELIZ_COMP
											WHERE NUM_IDENTIFICACAO =
											'{this.PRPFIDEL_NUM_IDENTIFICA}'
											AND IND_TP_INFORMACAO = '1'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PRPFIDCO_INFORM_COMPLEM { get; set; }
        public string PRPFIDEL_NUM_IDENTIFICA { get; set; }

        public static R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1 Execute(R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1 r0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1)
        {
            var ths = r0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0270_00_SELECT_PRPFIDCO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRPFIDCO_INFORM_COMPLEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}