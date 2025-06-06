using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1 : QueryBasis<R7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM
            SEGUROS.V0COMISSAO_FENAE
            WHERE NUMBIL = :V0BILH-NUMBIL
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM
				SEGUROS.V0COMISSAO_FENAE
				WHERE NUMBIL = '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string V0BILH_NUMBIL { get; set; }

        public static void Execute(R7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1 r7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1)
        {
            var ths = r7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7210_00_DELETE_V0COMISSAO_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}