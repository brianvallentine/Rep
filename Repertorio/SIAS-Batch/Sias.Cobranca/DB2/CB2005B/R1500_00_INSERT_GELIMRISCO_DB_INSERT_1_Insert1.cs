using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1 : QueryBasis<R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_LIMITE_DE_RISCO
            VALUES (:V0CLIE-CGCCPF ,
            :V0BILH-RAMO ,
            :GELMR-QTD-SEGUROS ,
            :GELMR-VLR-SOMA-IS ,
            CURRENT DATE ,
            'CB2005B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_LIMITE_DE_RISCO VALUES ({FieldThreatment(this.V0CLIE_CGCCPF)} , {FieldThreatment(this.V0BILH_RAMO)} , {FieldThreatment(this.GELMR_QTD_SEGUROS)} , {FieldThreatment(this.GELMR_VLR_SOMA_IS)} , CURRENT DATE , 'CB2005B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0CLIE_CGCCPF { get; set; }
        public string V0BILH_RAMO { get; set; }
        public string GELMR_QTD_SEGUROS { get; set; }
        public string GELMR_VLR_SOMA_IS { get; set; }

        public static void Execute(R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1 r1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1)
        {
            var ths = r1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1500_00_INSERT_GELIMRISCO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}