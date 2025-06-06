using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 : QueryBasis<R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO
            SEGUROS.V0APOLCOSCED
            VALUES
            (:V0ACOS-NUM-APOL ,
            :V0ACOS-CODCOSS ,
            :V0ACOS-RAMOFR ,
            :V0ACOS-DTINIVIG ,
            :V0ACOS-DTTERVIG ,
            :V0ACOS-PCPARTIC ,
            :V0ACOS-PCCOMCOS ,
            :V0ACOS-COD-EMPRESA:VIND-COD-EMP ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLCOSCED VALUES ({FieldThreatment(this.V0ACOS_NUM_APOL)} , {FieldThreatment(this.V0ACOS_CODCOSS)} , {FieldThreatment(this.V0ACOS_RAMOFR)} , {FieldThreatment(this.V0ACOS_DTINIVIG)} , {FieldThreatment(this.V0ACOS_DTTERVIG)} , {FieldThreatment(this.V0ACOS_PCPARTIC)} , {FieldThreatment(this.V0ACOS_PCCOMCOS)} ,  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0ACOS_COD_EMPRESA))} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0ACOS_NUM_APOL { get; set; }
        public string V0ACOS_CODCOSS { get; set; }
        public string V0ACOS_RAMOFR { get; set; }
        public string V0ACOS_DTINIVIG { get; set; }
        public string V0ACOS_DTTERVIG { get; set; }
        public string V0ACOS_PCPARTIC { get; set; }
        public string V0ACOS_PCCOMCOS { get; set; }
        public string V0ACOS_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }

        public static void Execute(R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 r1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1)
        {
            var ths = r1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}