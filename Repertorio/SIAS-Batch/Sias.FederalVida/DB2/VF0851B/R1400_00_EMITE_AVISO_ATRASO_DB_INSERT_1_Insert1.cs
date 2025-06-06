using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1 : QueryBasis<R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCOBVA
            VALUES (:V0PROP-NRCERTIF,
            :V0HCOB-NRPARCEL,
            :V0BANC-NRTIT,
            :V0HCOB-DTVENCTO,
            :WHOST-VLPREMIO,
            :V0OPCP-OPCAOPAG,
            '5' ,
            :V0HCOB-CODOPER,
            0,
            0,
            0,
            0,
            0,
            0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCOBVA VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0HCOB_NRPARCEL)}, {FieldThreatment(this.V0BANC_NRTIT)}, {FieldThreatment(this.V0HCOB_DTVENCTO)}, {FieldThreatment(this.WHOST_VLPREMIO)}, {FieldThreatment(this.V0OPCP_OPCAOPAG)}, '5' , {FieldThreatment(this.V0HCOB_CODOPER)}, 0, 0, 0, 0, 0, 0)";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0BANC_NRTIT { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string WHOST_VLPREMIO { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0HCOB_CODOPER { get; set; }

        public static void Execute(R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1 r1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1)
        {
            var ths = r1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_EMITE_AVISO_ATRASO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}