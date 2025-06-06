using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0999B
{
    public class R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.V0RELATORIOS
            WHERE IDSISTEM = 'CB'
            AND CODRELAT IN ( 'CB0100B1' ,
            'CB1000B1' ,
            'CB1005B1' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0RELATORIOS
				WHERE IDSISTEM = 'CB'
				AND CODRELAT IN ( 'CB0100B1' ,
				'CB1000B1' ,
				'CB1005B1' )";

            return query;
        }

        public static void Execute(R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 r0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = r0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}