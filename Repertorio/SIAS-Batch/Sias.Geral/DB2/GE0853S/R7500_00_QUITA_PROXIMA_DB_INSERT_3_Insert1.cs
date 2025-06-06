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
    public class R7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1 : QueryBasis<R7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0HISC-NRCERTIF,
            9999,
            :V0PROP-NRPARCEL,
            601,
            :V0PROP-DTVENCTO,
            0.00,
            0.00,
            0.00,
            0.00,
            :WHOST-PRMVG,
            :WHOST-PRMAP,
            0.00,
            ' ' )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0HISC_NRCERTIF)}, 9999, {FieldThreatment(this.V0PROP_NRPARCEL)}, 601, {FieldThreatment(this.V0PROP_DTVENCTO)}, 0.00, 0.00, 0.00, 0.00, {FieldThreatment(this.WHOST_PRMVG)}, {FieldThreatment(this.WHOST_PRMAP)}, 0.00, ' ' )";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string WHOST_PRMVG { get; set; }
        public string WHOST_PRMAP { get; set; }

        public static void Execute(R7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1 r7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1)
        {
            var ths = r7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}