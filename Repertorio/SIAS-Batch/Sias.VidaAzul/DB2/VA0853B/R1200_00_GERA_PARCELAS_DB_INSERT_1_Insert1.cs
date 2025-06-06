using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0PROP-NRCERTIF,
            9999,
            :V0PROP-NRPARCEL,
            680,
            :V0PROP-DTPROXVEN,
            0.00,
            0.00,
            0.00,
            0.00,
            :DESCON-PRMVG,
            :DESCON-PRMAP,
            0.00,
            ' ' )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, 9999, {FieldThreatment(this.V0PROP_NRPARCEL)}, 680, {FieldThreatment(this.V0PROP_DTPROXVEN)}, 0.00, 0.00, 0.00, 0.00, {FieldThreatment(this.DESCON_PRMVG)}, {FieldThreatment(this.DESCON_PRMAP)}, 0.00, ' ' )";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_DTPROXVEN { get; set; }
        public string DESCON_PRMVG { get; set; }
        public string DESCON_PRMAP { get; set; }

        public static void Execute(R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1 r1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1)
        {
            var ths = r1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}