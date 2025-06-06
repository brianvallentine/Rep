using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1 : QueryBasis<M_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0DIFPARCELVA
            VALUES (:V0HCTA-NRCERTIF,
            9999,
            :V0HCOB-NRPARCEL,
            601,
            :V0PARC-DTVENCTO,
            :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            :V0PARC-PRMVG,
            :V0PARC-PRMAP,
            0,
            ' ' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0DIFPARCELVA VALUES ({FieldThreatment(this.V0HCTA_NRCERTIF)}, 9999, {FieldThreatment(this.V0HCOB_NRPARCEL)}, 601, {FieldThreatment(this.V0PARC_DTVENCTO)}, {FieldThreatment(this.V0PARC_PRMVG)}, {FieldThreatment(this.V0PARC_PRMAP)}, {FieldThreatment(this.V0PARC_PRMVG)}, {FieldThreatment(this.V0PARC_PRMAP)}, {FieldThreatment(this.V0PARC_PRMVG)}, {FieldThreatment(this.V0PARC_PRMAP)}, 0, ' ' )";

            return query;
        }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }

        public static void Execute(M_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1 m_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1)
        {
            var ths = m_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1050_GERA_DIFERENCA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}