using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0004B
{
    public class R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1 : QueryBasis<R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1>
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
            :V0CHSI-OPERACAO ,
            :V0CHSI-DTMOVTO ,
            :V1CHSI-VAL-OPER ,
            CURRENT TIMESTAMP ,
            :V0CHSI-SITUACAO:VIND-SIT-REGT,
            :V1CHSI-TIPSGU:VIND-TIP-SEGR,
            :V0CHSI-SIT-LIBREC:VIND-SIT-LIBR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES ({FieldThreatment(this.V1CHSI_COD_EMPR)} , {FieldThreatment(this.V1CHSI_CONGENER)} , {FieldThreatment(this.V1CHSI_NUM_SINI)} , {FieldThreatment(this.V1CHSI_OCORHIST)} , {FieldThreatment(this.V0CHSI_OPERACAO)} , {FieldThreatment(this.V0CHSI_DTMOVTO)} , {FieldThreatment(this.V1CHSI_VAL_OPER)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_SIT_REGT?.ToInt() == -1 ? null : this.V0CHSI_SITUACAO))},  {FieldThreatment((this.VIND_TIP_SEGR?.ToInt() == -1 ? null : this.V1CHSI_TIPSGU))},  {FieldThreatment((this.VIND_SIT_LIBR?.ToInt() == -1 ? null : this.V0CHSI_SIT_LIBREC))})";

            return query;
        }
        public string V1CHSI_COD_EMPR { get; set; }
        public string V1CHSI_CONGENER { get; set; }
        public string V1CHSI_NUM_SINI { get; set; }
        public string V1CHSI_OCORHIST { get; set; }
        public string V0CHSI_OPERACAO { get; set; }
        public string V0CHSI_DTMOVTO { get; set; }
        public string V1CHSI_VAL_OPER { get; set; }
        public string V0CHSI_SITUACAO { get; set; }
        public string VIND_SIT_REGT { get; set; }
        public string V1CHSI_TIPSGU { get; set; }
        public string VIND_TIP_SEGR { get; set; }
        public string V0CHSI_SIT_LIBREC { get; set; }
        public string VIND_SIT_LIBR { get; set; }

        public static void Execute(R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1 r2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1)
        {
            var ths = r2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_INSERT_V0COSHISTSIN_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}