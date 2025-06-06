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
    public class R9984_00_LER_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R9984_00_LER_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :DCLBILHETE.BILHETE-SITUACAO
            FROM SEGUROS.BILHETE
            WHERE NUM_BILHETE =
            :DCLBILHETE.BILHETE-NUM-BILHETE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.BILHETE
											WHERE NUM_BILHETE =
											'{this.BILHETE_NUM_BILHETE}'
											WITH UR";

            return query;
        }
        public string BILHETE_SITUACAO { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R9984_00_LER_BILHETE_DB_SELECT_1_Query1 Execute(R9984_00_LER_BILHETE_DB_SELECT_1_Query1 r9984_00_LER_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r9984_00_LER_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9984_00_LER_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9984_00_LER_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}