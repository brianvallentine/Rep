using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1 : QueryBasis<R7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCOBVA
            VALUES (:V0PROP-NRCERTIF,
            :V0PROP-NRPARCEL,
            :WHOST-NRTIT,
            :V0PROP-DTVENCTO,
            0,
            :V0OPCP-OPCAOPAG,
            '1' ,
            115,
            0,
            0,
            0,
            0,
            0,
            0)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCOBVA VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, {FieldThreatment(this.WHOST_NRTIT)}, {FieldThreatment(this.V0PROP_DTVENCTO)}, 0, {FieldThreatment(this.V0OPCP_OPCAOPAG)}, '1' , 115, 0, 0, 0, 0, 0, 0)";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string WHOST_NRTIT { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }

        public static void Execute(R7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1 r7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1)
        {
            var ths = r7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}