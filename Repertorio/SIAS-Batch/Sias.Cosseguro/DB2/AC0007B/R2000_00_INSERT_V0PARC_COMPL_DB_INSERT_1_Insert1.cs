using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0007B
{
    public class R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1 : QueryBasis<R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0PARCELA_COMPL
            VALUES (:V0PCOM-NUM-APOL ,
            :V0PCOM-NRENDOS ,
            :V0PCOM-NRPARCEL ,
            :V0PCOM-VLR-COMPL-IX ,
            :V0PCOM-VLR-COMPL ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PARCELA_COMPL VALUES ({FieldThreatment(this.V0PCOM_NUM_APOL)} , {FieldThreatment(this.V0PCOM_NRENDOS)} , {FieldThreatment(this.V0PCOM_NRPARCEL)} , {FieldThreatment(this.V0PCOM_VLR_COMPL_IX)} , {FieldThreatment(this.V0PCOM_VLR_COMPL)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PCOM_NUM_APOL { get; set; }
        public string V0PCOM_NRENDOS { get; set; }
        public string V0PCOM_NRPARCEL { get; set; }
        public string V0PCOM_VLR_COMPL_IX { get; set; }
        public string V0PCOM_VLR_COMPL { get; set; }

        public static void Execute(R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1 r2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1)
        {
            var ths = r2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_INSERT_V0PARC_COMPL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}