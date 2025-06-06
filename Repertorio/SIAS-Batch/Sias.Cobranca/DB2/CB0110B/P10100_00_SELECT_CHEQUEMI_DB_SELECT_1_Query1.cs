using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1 : QueryBasis<P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE ( MAX ( NUM_CHEQUE_INTERNO ) , 0 )
            INTO :CHEQUEMI-NUM-CHEQUE-INTERNO
            FROM SEGUROS.CHEQUES_EMITIDOS
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE ( MAX ( NUM_CHEQUE_INTERNO ) 
							, 0 )
											FROM SEGUROS.CHEQUES_EMITIDOS
											WITH UR";

            return query;
        }
        public string CHEQUEMI_NUM_CHEQUE_INTERNO { get; set; }

        public static P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1 Execute(P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1 p10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1)
        {
            var ths = p10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1();
            var i = 0;
            dta.CHEQUEMI_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            return dta;
        }

    }
}