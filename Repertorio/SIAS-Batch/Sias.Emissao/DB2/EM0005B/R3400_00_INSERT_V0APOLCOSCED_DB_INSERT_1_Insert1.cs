using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0005B
{
    public class R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 : QueryBasis<R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLCOSCED
            VALUES (:V0ACCD-NUM-APOL ,
            :V0ACCD-CODCOSS ,
            :V0ACCD-RAMOFR ,
            :V0ACCD-DTINIVIG ,
            :V0ACCD-DTTERVIG ,
            :V0ACCD-PCPARTIC ,
            :V0ACCD-PCCOMCOS ,
            :V0ACCD-COD-EMPRESA:VIND-COD-EMP,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLCOSCED VALUES ({FieldThreatment(this.V0ACCD_NUM_APOL)} , {FieldThreatment(this.V0ACCD_CODCOSS)} , {FieldThreatment(this.V0ACCD_RAMOFR)} , {FieldThreatment(this.V0ACCD_DTINIVIG)} , {FieldThreatment(this.V0ACCD_DTTERVIG)} , {FieldThreatment(this.V0ACCD_PCPARTIC)} , {FieldThreatment(this.V0ACCD_PCCOMCOS)} ,  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0ACCD_COD_EMPRESA))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0ACCD_NUM_APOL { get; set; }
        public string V0ACCD_CODCOSS { get; set; }
        public string V0ACCD_RAMOFR { get; set; }
        public string V0ACCD_DTINIVIG { get; set; }
        public string V0ACCD_DTTERVIG { get; set; }
        public string V0ACCD_PCPARTIC { get; set; }
        public string V0ACCD_PCCOMCOS { get; set; }
        public string V0ACCD_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }

        public static void Execute(R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 r3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1)
        {
            var ths = r3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}