using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0056B
{
    public class R1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1 : QueryBasis<R1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE
            FROM SEGUROS.VG_ANDAMENTO_PROP
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND COD_USUARIO = 'VA0055B'
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.VG_ANDAMENTO_PROP
				WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
				AND COD_USUARIO = 'VA0055B'";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1 r1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1)
        {
            var ths = r1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}