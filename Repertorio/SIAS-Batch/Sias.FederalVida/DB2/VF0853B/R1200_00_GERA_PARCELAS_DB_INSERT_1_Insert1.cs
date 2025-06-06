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
    public class R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0PARCELVA
            VALUES (:V0PROP-NRCERTIF,
            :V0PROP-NRPARCEL,
            :V0PROP-DTVENCTO,
            :V0COBP-PRMVG,
            :V0COBP-PRMAP,
            0,
            :V0OPCP-OPCAOPAG,
            :V0PARC-SITUACAO,
            :V0PARC-OCORHIST,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PARCELVA VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.V0PROP_NRPARCEL)}, {FieldThreatment(this.V0PROP_DTVENCTO)}, {FieldThreatment(this.V0COBP_PRMVG)}, {FieldThreatment(this.V0COBP_PRMAP)}, 0, {FieldThreatment(this.V0OPCP_OPCAOPAG)}, {FieldThreatment(this.V0PARC_SITUACAO)}, {FieldThreatment(this.V0PARC_OCORHIST)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0COBP_PRMVG { get; set; }
        public string V0COBP_PRMAP { get; set; }
        public string V0OPCP_OPCAOPAG { get; set; }
        public string V0PARC_SITUACAO { get; set; }
        public string V0PARC_OCORHIST { get; set; }

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