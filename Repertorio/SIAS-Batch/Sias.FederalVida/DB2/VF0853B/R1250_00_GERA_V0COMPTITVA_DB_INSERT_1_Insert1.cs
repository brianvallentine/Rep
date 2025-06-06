using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0853B
{
    public class R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1 : QueryBasis<R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COMPTITVA
            VALUES (:W-TITULO,
            :V0COMP-NRPARCEL,
            :V0COMP-CODOPER,
            :V0COMP-PRMDIFVG,
            :V0COMP-PRMDIFAP,
            :V1SIST-DTMOVABE,
            'VF0853B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COMPTITVA VALUES ({FieldThreatment(this.W_TITULO)}, {FieldThreatment(this.V0COMP_NRPARCEL)}, {FieldThreatment(this.V0COMP_CODOPER)}, {FieldThreatment(this.V0COMP_PRMDIFVG)}, {FieldThreatment(this.V0COMP_PRMDIFAP)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, 'VF0853B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string W_TITULO { get; set; }
        public string V0COMP_NRPARCEL { get; set; }
        public string V0COMP_CODOPER { get; set; }
        public string V0COMP_PRMDIFVG { get; set; }
        public string V0COMP_PRMDIFAP { get; set; }
        public string V1SIST_DTMOVABE { get; set; }

        public static void Execute(R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1 r1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1)
        {
            var ths = r1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1250_00_GERA_V0COMPTITVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}