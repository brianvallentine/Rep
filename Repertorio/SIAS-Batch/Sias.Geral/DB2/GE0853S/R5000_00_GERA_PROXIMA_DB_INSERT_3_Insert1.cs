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
    public class R5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1 : QueryBasis<R5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0PARCELVA
            VALUES (:V0PROP-NRCERTIF,
            :V0PROP-NRPARCEL,
            :V0PROP-DTVENCTO,
            :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            0,
            :V0OPCP-OPCAOPAG,
            ' ' ,
            0,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PARCELVA VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, {FieldThreatment(this.V0PROP_DTVENCTO)}, {FieldThreatment(this.V0PARC_PRMVG)}, {FieldThreatment(this.V0PARC_PRMAP)}, 0, {FieldThreatment(this.V0OPCP_OPCAOPAG)}, ' ' , 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }

        public static void Execute(R5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1 r5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1)
        {
            var ths = r5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}