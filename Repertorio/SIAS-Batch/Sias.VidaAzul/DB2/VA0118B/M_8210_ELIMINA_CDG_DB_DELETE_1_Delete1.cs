using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1 : QueryBasis<M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.V0CDGCOBER
            WHERE CODCLIEN = :PROPVA-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.V0CDGCOBER
				WHERE CODCLIEN = '{this.PROPVA_CODCLIEN}'";

            return query;
        }
        public string PROPVA_CODCLIEN { get; set; }

        public static void Execute(M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1 m_8210_ELIMINA_CDG_DB_DELETE_1_Delete1)
        {
            var ths = m_8210_ELIMINA_CDG_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}