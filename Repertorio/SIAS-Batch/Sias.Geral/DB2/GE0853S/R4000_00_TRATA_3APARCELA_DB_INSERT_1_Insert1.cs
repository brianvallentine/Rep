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
    public class R4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1 : QueryBasis<R4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0HISC-NRCERTIF,
            :V0PROP-NRPARCEL,
            :V0PROP-NRPARCEL,
            :WHOST-CODOPER1,
            :V0PROP-DTVENCTO,
            :V0COBP-PRMVG,
            :V0COBP-PRMAP,
            0,
            0,
            :V0COBP-PRMVG,
            :V0COBP-PRMAP,
            0,
            '1' )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0HISC_NRCERTIF)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, {FieldThreatment(this.WHOST_CODOPER1)}, {FieldThreatment(this.V0PROP_DTVENCTO)}, {FieldThreatment(this.V0COBP_PRMVG)}, {FieldThreatment(this.V0COBP_PRMAP)}, 0, 0, {FieldThreatment(this.V0COBP_PRMVG)}, {FieldThreatment(this.V0COBP_PRMAP)}, 0, '1' )";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string WHOST_CODOPER1 { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0COBP_PRMVG { get; set; }
        public string V0COBP_PRMAP { get; set; }

        public static void Execute(R4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1 r4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1)
        {
            var ths = r4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}