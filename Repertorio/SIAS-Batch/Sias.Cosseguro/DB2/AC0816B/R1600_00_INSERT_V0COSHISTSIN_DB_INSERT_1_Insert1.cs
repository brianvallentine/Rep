using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1 : QueryBasis<R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_HISTSIN
            VALUES (:V1CHSI-COD-EMPR ,
            :V1CHSI-CONGENER ,
            :V1CHSI-NUM-SINI ,
            :V1CHSI-OCORHIST ,
            :WHOST-OPER-COR ,
            :V0SIST-DTMOVABE ,
            :WHOST-VAL-CORR ,
            CURRENT TIMESTAMP ,
            :V1CHSI-SITUACAO:VIND-SIT-REGT,
            :V1CHSI-TIPSGU:VIND-TIP-SEGR,
            :V1CHSI-SIT-LIBREC:VIND-SIT-LIBR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES ({FieldThreatment(this.V1CHSI_COD_EMPR)} , {FieldThreatment(this.V1CHSI_CONGENER)} , {FieldThreatment(this.V1CHSI_NUM_SINI)} , {FieldThreatment(this.V1CHSI_OCORHIST)} , {FieldThreatment(this.WHOST_OPER_COR)} , {FieldThreatment(this.V0SIST_DTMOVABE)} , {FieldThreatment(this.WHOST_VAL_CORR)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_SIT_REGT?.ToInt() == -1 ? null : this.V1CHSI_SITUACAO))},  {FieldThreatment((this.VIND_TIP_SEGR?.ToInt() == -1 ? null : this.V1CHSI_TIPSGU))},  {FieldThreatment((this.VIND_SIT_LIBR?.ToInt() == -1 ? null : this.V1CHSI_SIT_LIBREC))})";

            return query;
        }
        public string V1CHSI_COD_EMPR { get; set; }
        public string V1CHSI_CONGENER { get; set; }
        public string V1CHSI_NUM_SINI { get; set; }
        public string V1CHSI_OCORHIST { get; set; }
        public string WHOST_OPER_COR { get; set; }
        public string V0SIST_DTMOVABE { get; set; }
        public string WHOST_VAL_CORR { get; set; }
        public string V1CHSI_SITUACAO { get; set; }
        public string VIND_SIT_REGT { get; set; }
        public string V1CHSI_TIPSGU { get; set; }
        public string VIND_TIP_SEGR { get; set; }
        public string V1CHSI_SIT_LIBREC { get; set; }
        public string VIND_SIT_LIBR { get; set; }

        public static void Execute(R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1 r1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1)
        {
            var ths = r1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1600_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}