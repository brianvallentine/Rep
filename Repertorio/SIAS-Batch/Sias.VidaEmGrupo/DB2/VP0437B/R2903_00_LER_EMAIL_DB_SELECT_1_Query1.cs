using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R2903_00_LER_EMAIL_DB_SELECT_1_Query1 : QueryBasis<R2903_00_LER_EMAIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT EMAIL
            INTO :EMAIL
            FROM SEGUROS.PESSOA_EMAIL
            WHERE COD_PESSOA = :PROPOFID-COD-PESSOA
            ORDER BY SEQ_EMAIL DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT EMAIL
											FROM SEGUROS.PESSOA_EMAIL
											WHERE COD_PESSOA = '{this.PROPOFID_COD_PESSOA}'
											ORDER BY SEQ_EMAIL DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string EMAIL { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }

        public static R2903_00_LER_EMAIL_DB_SELECT_1_Query1 Execute(R2903_00_LER_EMAIL_DB_SELECT_1_Query1 r2903_00_LER_EMAIL_DB_SELECT_1_Query1)
        {
            var ths = r2903_00_LER_EMAIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2903_00_LER_EMAIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2903_00_LER_EMAIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}