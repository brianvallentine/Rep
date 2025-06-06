using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0017B
{
    public class R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1 : QueryBasis<R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_SINI
            VALUES (:V2CSIN-COD-EMP,
            :V2CSIN-TIPSGU,
            :V2CSIN-CONGENER,
            :V2CSIN-NUM-SINI,
            :V2CSIN-VAL-OPER,
            :V2CSIN-SITUACAO,
            :V2CSIN-SIT-CONG,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_SINI VALUES ({FieldThreatment(this.V2CSIN_COD_EMP)}, {FieldThreatment(this.V2CSIN_TIPSGU)}, {FieldThreatment(this.V2CSIN_CONGENER)}, {FieldThreatment(this.V2CSIN_NUM_SINI)}, {FieldThreatment(this.V2CSIN_VAL_OPER)}, {FieldThreatment(this.V2CSIN_SITUACAO)}, {FieldThreatment(this.V2CSIN_SIT_CONG)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V2CSIN_COD_EMP { get; set; }
        public string V2CSIN_TIPSGU { get; set; }
        public string V2CSIN_CONGENER { get; set; }
        public string V2CSIN_NUM_SINI { get; set; }
        public string V2CSIN_VAL_OPER { get; set; }
        public string V2CSIN_SITUACAO { get; set; }
        public string V2CSIN_SIT_CONG { get; set; }

        public static void Execute(R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1 r4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1)
        {
            var ths = r4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4300_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}