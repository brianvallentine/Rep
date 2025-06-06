using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :DCLPROPOSTAS-VA.SIT-REGISTRO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.NUM_CERTIFICADO}'";

            return query;
        }
        public string SIT_REGISTRO { get; set; }
        public string NUM_CERTIFICADO { get; set; }

        public static R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 Execute(R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 r5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = r5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}