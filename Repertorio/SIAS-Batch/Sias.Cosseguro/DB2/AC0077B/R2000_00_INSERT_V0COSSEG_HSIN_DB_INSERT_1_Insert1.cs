using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0077B
{
    public class R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1 : QueryBasis<R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_HISTSIN
            VALUES (:V0CHSI-COD-EMP,
            :V0CHSI-CONGENER,
            :V0CHSI-NUM-SINI,
            :V0CHSI-OCORHIST,
            :V0CHSI-OPERACAO,
            :V0CHSI-DTMOVTO,
            :V0CHSI-VAL-OPER,
            CURRENT TIMESTAMP,
            :V0CHSI-SITUACAO:VIND-SIT-REGT,
            :V0CHSI-TIPSGU:VIND-TIP-SEGR,
            :V0CHSI-SIT-LIBRC:VIND-SIT-LIBR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES ({FieldThreatment(this.V0CHSI_COD_EMP)}, {FieldThreatment(this.V0CHSI_CONGENER)}, {FieldThreatment(this.V0CHSI_NUM_SINI)}, {FieldThreatment(this.V0CHSI_OCORHIST)}, {FieldThreatment(this.V0CHSI_OPERACAO)}, {FieldThreatment(this.V0CHSI_DTMOVTO)}, {FieldThreatment(this.V0CHSI_VAL_OPER)}, CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_SIT_REGT?.ToInt() == -1 ? null : this.V0CHSI_SITUACAO))},  {FieldThreatment((this.VIND_TIP_SEGR?.ToInt() == -1 ? null : this.V0CHSI_TIPSGU))},  {FieldThreatment((this.VIND_SIT_LIBR?.ToInt() == -1 ? null : this.V0CHSI_SIT_LIBRC))})";

            return query;
        }
        public string V0CHSI_COD_EMP { get; set; }
        public string V0CHSI_CONGENER { get; set; }
        public string V0CHSI_NUM_SINI { get; set; }
        public string V0CHSI_OCORHIST { get; set; }
        public string V0CHSI_OPERACAO { get; set; }
        public string V0CHSI_DTMOVTO { get; set; }
        public string V0CHSI_VAL_OPER { get; set; }
        public string V0CHSI_SITUACAO { get; set; }
        public string VIND_SIT_REGT { get; set; }
        public string V0CHSI_TIPSGU { get; set; }
        public string VIND_TIP_SEGR { get; set; }
        public string V0CHSI_SIT_LIBRC { get; set; }
        public string VIND_SIT_LIBR { get; set; }

        public static void Execute(R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1 r2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1)
        {
            var ths = r2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}