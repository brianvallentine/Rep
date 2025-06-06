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
    public class R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1 : QueryBasis<R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COMPTITVA
            VALUES (:V0BANC-NRTIT,
            :V0COMP-NRPARCEL,
            :V0COMP-CODOPER,
            :V0COMP-PRMDIFVG,
            :V0COMP-PRMDIFAP,
            CURRENT DATE,
            'VF0851B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COMPTITVA VALUES ({FieldThreatment(this.V0BANC_NRTIT)}, {FieldThreatment(this.V0COMP_NRPARCEL)}, {FieldThreatment(this.V0COMP_CODOPER)}, {FieldThreatment(this.V0COMP_PRMDIFVG)}, {FieldThreatment(this.V0COMP_PRMDIFAP)}, CURRENT DATE, 'VF0851B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0BANC_NRTIT { get; set; }
        public string V0COMP_NRPARCEL { get; set; }
        public string V0COMP_CODOPER { get; set; }
        public string V0COMP_PRMDIFVG { get; set; }
        public string V0COMP_PRMDIFAP { get; set; }

        public static void Execute(R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1 r1410_00_MONTA_TITULO_DB_INSERT_1_Insert1)
        {
            var ths = r1410_00_MONTA_TITULO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1410_00_MONTA_TITULO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}