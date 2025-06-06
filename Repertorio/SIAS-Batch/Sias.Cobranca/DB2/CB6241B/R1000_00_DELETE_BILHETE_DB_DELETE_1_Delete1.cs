using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6241B
{
    public class R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1 : QueryBasis<R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE
            FROM SEGUROS.BILHETE
            WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.BILHETE
				WHERE NUM_BILHETE = '{this.BILHETE_NUM_BILHETE}'";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static void Execute(R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1 r1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1)
        {
            var ths = r1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_DELETE_BILHETE_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}