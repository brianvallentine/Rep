using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0617B
{
    public class R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1 : QueryBasis<R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOL_ANTERIOR
            INTO :BILHETE-NUM-APOL-ANTERIOR
            FROM SEGUROS.BILHETE
            WHERE NUM_BILHETE = :NUM-APOL-ANT
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOL_ANTERIOR
											FROM SEGUROS.BILHETE
											WHERE NUM_BILHETE = '{this.NUM_APOL_ANT}'
											WITH UR";

            return query;
        }
        public string BILHETE_NUM_APOL_ANTERIOR { get; set; }
        public string NUM_APOL_ANT { get; set; }

        public static R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1 Execute(R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1 r0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1)
        {
            var ths = r0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_NUM_APOL_ANTERIOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}