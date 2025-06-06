using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0805B
{
    public class M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1 : QueryBasis<M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.V0FITACEF
            WHERE NSAC = :FITCEF-NSA
            END-EXEC
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0FITACEF
				WHERE NSAC = '{this.FITCEF_NSA}'";

            return query;
        }
        public string FITCEF_NSA { get; set; }

        public static void Execute(M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1 m_0011_CONSISTE_NSA_DB_DELETE_1_Delete1)
        {
            var ths = m_0011_CONSISTE_NSA_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0011_CONSISTE_NSA_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}