using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1 : QueryBasis<R0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.CLIENTE_EMAIL
            VALUES (:CLIENEMA-COD-CLIENTE ,
            :CLIENEMA-SEQ-EMAIL ,
            :CLIENEMA-EMAIL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES ({FieldThreatment(this.CLIENEMA_COD_CLIENTE)} , {FieldThreatment(this.CLIENEMA_SEQ_EMAIL)} , {FieldThreatment(this.CLIENEMA_EMAIL)} )";

            return query;
        }
        public string CLIENEMA_COD_CLIENTE { get; set; }
        public string CLIENEMA_SEQ_EMAIL { get; set; }
        public string CLIENEMA_EMAIL { get; set; }

        public static void Execute(R0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1 r0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1)
        {
            var ths = r0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0538_00_INSERT_EMAIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}