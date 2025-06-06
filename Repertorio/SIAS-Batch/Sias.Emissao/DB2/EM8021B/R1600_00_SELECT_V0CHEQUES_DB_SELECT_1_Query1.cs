using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8021B
{
    public class R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1 : QueryBasis<R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FAVORECIDO
            INTO :CHEQUEMI-COD-FAVORECIDO
            FROM SEGUROS.CHEQUES_EMITIDOS
            WHERE NUM_CHEQUE_INTERNO =
            :CHEQUEMI-NUM-CHEQUE-INTERNO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FAVORECIDO
											FROM SEGUROS.CHEQUES_EMITIDOS
											WHERE NUM_CHEQUE_INTERNO =
											'{this.CHEQUEMI_NUM_CHEQUE_INTERNO}'
											WITH UR";

            return query;
        }
        public string CHEQUEMI_COD_FAVORECIDO { get; set; }
        public string CHEQUEMI_NUM_CHEQUE_INTERNO { get; set; }

        public static R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1 Execute(R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1 r1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1();
            var i = 0;
            dta.CHEQUEMI_COD_FAVORECIDO = result[i++].Value?.ToString();
            return dta;
        }

    }
}