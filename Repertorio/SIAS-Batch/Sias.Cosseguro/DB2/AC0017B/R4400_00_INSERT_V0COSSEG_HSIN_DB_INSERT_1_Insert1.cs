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
    public class R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1 : QueryBasis<R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_HISTSIN
            VALUES (:V2CHSI-COD-EMP,
            :V2CHSI-CONGENER,
            :V2CHSI-NUM-SINI,
            :V2CHSI-OCORHIST,
            :V2CHSI-OPERACAO,
            :V2CHSI-DTMOVTO,
            :V2CHSI-VAL-OPER,
            CURRENT TIMESTAMP,
            :V2CHSI-SITUACAO:VIND-SIT-REGT,
            :V2CHSI-TIPSGU:VIND-TIP-SEGR,
            :V2CHSI-SIT-LIBRECUP:VIND-SIT-LIBR)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_HISTSIN VALUES ({FieldThreatment(this.V2CHSI_COD_EMP)}, {FieldThreatment(this.V2CHSI_CONGENER)}, {FieldThreatment(this.V2CHSI_NUM_SINI)}, {FieldThreatment(this.V2CHSI_OCORHIST)}, {FieldThreatment(this.V2CHSI_OPERACAO)}, {FieldThreatment(this.V2CHSI_DTMOVTO)}, {FieldThreatment(this.V2CHSI_VAL_OPER)}, CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_SIT_REGT?.ToInt() == -1 ? null : this.V2CHSI_SITUACAO))},  {FieldThreatment((this.VIND_TIP_SEGR?.ToInt() == -1 ? null : this.V2CHSI_TIPSGU))},  {FieldThreatment((this.VIND_SIT_LIBR?.ToInt() == -1 ? null : this.V2CHSI_SIT_LIBRECUP))})";

            return query;
        }
        public string V2CHSI_COD_EMP { get; set; }
        public string V2CHSI_CONGENER { get; set; }
        public string V2CHSI_NUM_SINI { get; set; }
        public string V2CHSI_OCORHIST { get; set; }
        public string V2CHSI_OPERACAO { get; set; }
        public string V2CHSI_DTMOVTO { get; set; }
        public string V2CHSI_VAL_OPER { get; set; }
        public string V2CHSI_SITUACAO { get; set; }
        public string VIND_SIT_REGT { get; set; }
        public string V2CHSI_TIPSGU { get; set; }
        public string VIND_TIP_SEGR { get; set; }
        public string V2CHSI_SIT_LIBRECUP { get; set; }
        public string VIND_SIT_LIBR { get; set; }

        public static void Execute(R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1 r4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1)
        {
            var ths = r4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4400_00_INSERT_V0COSSEG_HSIN_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}