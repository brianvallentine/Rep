using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1 : QueryBasis<R3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.V0RCAP
            WHERE FONTE = :V0RCOM-FONTE
            AND NRRCAP = :V0RCOM-NRRCAP
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0RCAP
				WHERE FONTE = '{this.V0RCOM_FONTE}'
				AND NRRCAP = '{this.V0RCOM_NRRCAP}'";

            return query;
        }
        public string V0RCOM_FONTE { get; set; }
        public string V0RCOM_NRRCAP { get; set; }

        public static void Execute(R3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1 r3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1)
        {
            var ths = r3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3860_UPDATE_V0RCAP_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}