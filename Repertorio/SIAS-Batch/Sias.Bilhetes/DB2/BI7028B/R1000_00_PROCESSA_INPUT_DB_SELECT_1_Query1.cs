using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT QTD_DIG_COMBINACAO
            INTO :FCPLANO-QTD-DIG-COMBINACAO
            FROM FDRCAP.FC_PLANO
            WHERE NUM_PLANO = :FCPLANO-NUM-PLANO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT QTD_DIG_COMBINACAO
											FROM FDRCAP.FC_PLANO
											WHERE NUM_PLANO = '{this.FCPLANO_NUM_PLANO}'
											WITH UR";

            return query;
        }
        public string FCPLANO_QTD_DIG_COMBINACAO { get; set; }
        public string FCPLANO_NUM_PLANO { get; set; }

        public static R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1();
            var i = 0;
            dta.FCPLANO_QTD_DIG_COMBINACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}