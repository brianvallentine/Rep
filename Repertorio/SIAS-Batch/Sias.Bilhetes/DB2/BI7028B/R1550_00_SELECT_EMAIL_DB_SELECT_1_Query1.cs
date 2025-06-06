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
    public class R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1 : QueryBasis<R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT EMAIL
            INTO :PESSOEMA-EMAIL
            FROM SEGUROS.PESSOA_EMAIL
            WHERE COD_PESSOA = :PROPOFID-COD-PESSOA
            ORDER BY SEQ_EMAIL DESC
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT EMAIL
											FROM SEGUROS.PESSOA_EMAIL
											WHERE COD_PESSOA = '{this.PROPOFID_COD_PESSOA}'
											ORDER BY SEQ_EMAIL DESC
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string PESSOEMA_EMAIL { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }

        public static R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1 Execute(R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1 r1550_00_SELECT_EMAIL_DB_SELECT_1_Query1)
        {
            var ths = r1550_00_SELECT_EMAIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1550_00_SELECT_EMAIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOEMA_EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}