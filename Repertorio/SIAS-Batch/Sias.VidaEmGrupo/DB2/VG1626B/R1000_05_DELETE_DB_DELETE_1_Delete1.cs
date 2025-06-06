using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R1000_05_DELETE_DB_DELETE_1_Delete1 : QueryBasis<R1000_05_DELETE_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND OCORR_HISTORICO > :PROPOVA-OCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.HIS_COBER_PROPOST
				WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
				AND OCORR_HISTORICO > '{this.PROPOVA_OCORR_HISTORICO}'";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }

        public static void Execute(R1000_05_DELETE_DB_DELETE_1_Delete1 r1000_05_DELETE_DB_DELETE_1_Delete1)
        {
            var ths = r1000_05_DELETE_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_05_DELETE_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}