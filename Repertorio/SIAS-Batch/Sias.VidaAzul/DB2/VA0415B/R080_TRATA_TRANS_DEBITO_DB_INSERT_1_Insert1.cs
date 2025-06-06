using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0415B
{
    public class R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1 : QueryBasis<R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTREPSAF
            VALUES (:V0PROP-CODCLIEN,
            :V0HSEG-DTREFER,
            :V0PROP-NRCERTIF,
            00,
            :V0PROP-NUM-MATRICULA,
            :V0COBV-VLCUSTAUXF,
            :V0PROP-CODOPER,
            '7' ,
            '0' ,
            000,
            000,
            'VA0415B' ,
            CURRENT TIMESTAMP,
            :V0HSEG-DTREFER:VIND-DTMOVTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTREPSAF VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0HSEG_DTREFER)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, 00, {FieldThreatment(this.V0PROP_NUM_MATRICULA)}, {FieldThreatment(this.V0COBV_VLCUSTAUXF)}, {FieldThreatment(this.V0PROP_CODOPER)}, '7' , '0' , 000, 000, 'VA0415B' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.V0HSEG_DTREFER))})";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0HSEG_DTREFER { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NUM_MATRICULA { get; set; }
        public string V0COBV_VLCUSTAUXF { get; set; }
        public string V0PROP_CODOPER { get; set; }
        public string VIND_DTMOVTO { get; set; }

        public static void Execute(R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1 r080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1)
        {
            var ths = r080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}