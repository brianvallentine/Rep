using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1 : QueryBasis<R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0CLIENTE_CROT
            VALUES (:V0CROT-CGCCPF ,
            :V0CROT-BILH-AP ,
            :V0CROT-BILH-RES ,
            :V0CROT-BILH-VDAZUL ,
            :V0CROT-DTMOVABE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CLIENTE_CROT VALUES ({FieldThreatment(this.V0CROT_CGCCPF)} , {FieldThreatment(this.V0CROT_BILH_AP)} , {FieldThreatment(this.V0CROT_BILH_RES)} , {FieldThreatment(this.V0CROT_BILH_VDAZUL)} , {FieldThreatment(this.V0CROT_DTMOVABE)})";

            return query;
        }
        public string V0CROT_CGCCPF { get; set; }
        public string V0CROT_BILH_AP { get; set; }
        public string V0CROT_BILH_RES { get; set; }
        public string V0CROT_BILH_VDAZUL { get; set; }
        public string V0CROT_DTMOVABE { get; set; }

        public static void Execute(R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1 r3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1)
        {
            var ths = r3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3260_00_INSERT_V0CLIEN_CROT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}