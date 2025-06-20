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
    public class R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1 : QueryBasis<R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.CLIENTE_EMAIL
            VALUES (:DCLCLIENTES.COD-CLIENTE,
            :CLIENEMA-SEQ-EMAIL,
            :WHOST-EMAIL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES ({FieldThreatment(this.COD_CLIENTE)}, {FieldThreatment(this.CLIENEMA_SEQ_EMAIL)}, {FieldThreatment(this.WHOST_EMAIL)})";

            return query;
        }
        public string COD_CLIENTE { get; set; }
        public string CLIENEMA_SEQ_EMAIL { get; set; }
        public string WHOST_EMAIL { get; set; }

        public static void Execute(R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1 r2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1)
        {
            var ths = r2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}