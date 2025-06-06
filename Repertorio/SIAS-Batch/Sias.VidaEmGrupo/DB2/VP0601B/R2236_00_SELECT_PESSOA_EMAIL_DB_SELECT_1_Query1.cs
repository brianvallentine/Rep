using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1 : QueryBasis<R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT EMAIL
            INTO :WHOST-EMAIL
            FROM SEGUROS.PESSOA_EMAIL
            WHERE COD_PESSOA =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA
            AND SITUACAO_EMAIL = 'P'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT EMAIL
											FROM SEGUROS.PESSOA_EMAIL
											WHERE COD_PESSOA =
											'{this.PROPOFID_COD_PESSOA}'
											AND SITUACAO_EMAIL = 'P'";

            return query;
        }
        public string WHOST_EMAIL { get; set; }
        public string PROPOFID_COD_PESSOA { get; set; }

        public static R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1 Execute(R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1 r2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1)
        {
            var ths = r2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}