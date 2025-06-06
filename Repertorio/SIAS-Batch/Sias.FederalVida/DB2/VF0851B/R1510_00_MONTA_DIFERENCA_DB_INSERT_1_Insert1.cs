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
    public class R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1 : QueryBasis<R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COMPTITVA
            VALUES (:V0BANC-NRTIT,
            :V0DIFP-NRPARCEL,
            :V0DIFP-CODOPER,
            :V0DIFP-PRMDIFVG,
            :V0DIFP-PRMDIFAP,
            CURRENT DATE,
            'VF0851B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COMPTITVA VALUES ({FieldThreatment(this.V0BANC_NRTIT)}, {FieldThreatment(this.V0DIFP_NRPARCEL)}, {FieldThreatment(this.V0DIFP_CODOPER)}, {FieldThreatment(this.V0DIFP_PRMDIFVG)}, {FieldThreatment(this.V0DIFP_PRMDIFAP)}, CURRENT DATE, 'VF0851B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0BANC_NRTIT { get; set; }
        public string V0DIFP_NRPARCEL { get; set; }
        public string V0DIFP_CODOPER { get; set; }
        public string V0DIFP_PRMDIFVG { get; set; }
        public string V0DIFP_PRMDIFAP { get; set; }

        public static void Execute(R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1 r1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1)
        {
            var ths = r1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1510_00_MONTA_DIFERENCA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}