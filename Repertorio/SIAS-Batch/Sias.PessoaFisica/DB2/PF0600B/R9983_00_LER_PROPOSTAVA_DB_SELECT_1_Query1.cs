using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :DCLPROPOSTAS-VA.PROPOVA-SIT-REGISTRO
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO =
            :DCLPROPOSTAS-VA.PROPOVA-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO =
											'{this.PROPOVA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 Execute(R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 r9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = r9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9983_00_LER_PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}