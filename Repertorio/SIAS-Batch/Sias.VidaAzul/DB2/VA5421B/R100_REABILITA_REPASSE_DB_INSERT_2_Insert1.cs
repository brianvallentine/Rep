using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5421B
{
    public class R100_REABILITA_REPASSE_DB_INSERT_2_Insert1 : QueryBasis<R100_REABILITA_REPASSE_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTREPSAF
            VALUES (:V0PROP-CODCLIEN,
            :V0SAFC-DTINIVIG,
            :V0PROP-NRCERTIF,
            :V0SAFC-OCORHIST,
            :V0PROP-NUM-MATRICULA,
            :V0COBV-VLCUSTAUXF,
            :V0HSAF-CODOPER,
            '0' ,
            '0' ,
            000,
            000,
            'VA5421B' ,
            CURRENT TIMESTAMP,
            :V0SAFC-DTINIVIG:VIND-DTMOVTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTREPSAF VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0SAFC_DTINIVIG)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0SAFC_OCORHIST)}, {FieldThreatment(this.V0PROP_NUM_MATRICULA)}, {FieldThreatment(this.V0COBV_VLCUSTAUXF)}, {FieldThreatment(this.V0HSAF_CODOPER)}, '0' , '0' , 000, 000, 'VA5421B' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.V0SAFC_DTINIVIG))})";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0SAFC_DTINIVIG { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0SAFC_OCORHIST { get; set; }
        public string V0PROP_NUM_MATRICULA { get; set; }
        public string V0COBV_VLCUSTAUXF { get; set; }
        public string V0HSAF_CODOPER { get; set; }
        public string VIND_DTMOVTO { get; set; }

        public static void Execute(R100_REABILITA_REPASSE_DB_INSERT_2_Insert1 r100_REABILITA_REPASSE_DB_INSERT_2_Insert1)
        {
            var ths = r100_REABILITA_REPASSE_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R100_REABILITA_REPASSE_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}