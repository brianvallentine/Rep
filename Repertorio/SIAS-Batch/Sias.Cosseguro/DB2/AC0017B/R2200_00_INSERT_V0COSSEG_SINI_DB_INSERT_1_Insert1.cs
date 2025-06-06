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
    public class R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1 : QueryBasis<R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_SINI
            VALUES (:V0CSIN-COD-EMP,
            :V0CSIN-TIPSGU,
            :V0CSIN-CONGENER,
            :V0CSIN-NUM-SINI,
            :V0CSIN-VAL-OPER,
            :V0CSIN-SITUACAO,
            :V0CSIN-SIT-CONG,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_SINI VALUES ({FieldThreatment(this.V0CSIN_COD_EMP)}, {FieldThreatment(this.V0CSIN_TIPSGU)}, {FieldThreatment(this.V0CSIN_CONGENER)}, {FieldThreatment(this.V0CSIN_NUM_SINI)}, {FieldThreatment(this.V0CSIN_VAL_OPER)}, {FieldThreatment(this.V0CSIN_SITUACAO)}, {FieldThreatment(this.V0CSIN_SIT_CONG)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0CSIN_COD_EMP { get; set; }
        public string V0CSIN_TIPSGU { get; set; }
        public string V0CSIN_CONGENER { get; set; }
        public string V0CSIN_NUM_SINI { get; set; }
        public string V0CSIN_VAL_OPER { get; set; }
        public string V0CSIN_SITUACAO { get; set; }
        public string V0CSIN_SIT_CONG { get; set; }

        public static void Execute(R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1 r2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1)
        {
            var ths = r2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2200_00_INSERT_V0COSSEG_SINI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}