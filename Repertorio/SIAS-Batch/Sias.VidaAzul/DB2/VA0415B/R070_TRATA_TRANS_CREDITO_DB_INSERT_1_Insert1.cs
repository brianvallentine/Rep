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
    public class R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1 : QueryBasis<R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0SAFCOBER
            VALUES (:V0PROP-CODCLIEN,
            :V0HSEG-DTREFER,
            '9999-12-31' ,
            :V0COBV-IMPSEGAUXF,
            :V0COBV-VLCUSTAUXF,
            :V0PROP-NRCERTIF,
            01,
            '0' ,
            'VA0415B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0SAFCOBER VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0HSEG_DTREFER)}, '9999-12-31' , {FieldThreatment(this.V0COBV_IMPSEGAUXF)}, {FieldThreatment(this.V0COBV_VLCUSTAUXF)}, {FieldThreatment(this.V0PROP_NRCERTIF)}, 01, '0' , 'VA0415B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0HSEG_DTREFER { get; set; }
        public string V0COBV_IMPSEGAUXF { get; set; }
        public string V0COBV_VLCUSTAUXF { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1 r070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1)
        {
            var ths = r070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}