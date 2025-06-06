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
    public class M_1040_LOOP_DB_INSERT_1_Insert1 : QueryBasis<M_1040_LOOP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0EVENTOSVF
            VALUES (:V0PLCO-CODPDT,
            :V0PDTV-OCORHIST,
            0,
            :V0HCTA-NRCERTIF,
            :V0PARC-NRPARCEL,
            8,
            202,
            :V0SIST-DTMOVABE,
            :V0HCOB-DTVENCTO,
            '0' ,
            :V0CMPT-VLPRMDIF,
            0,
            'VF0813B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0EVENTOSVF VALUES ({FieldThreatment(this.V0PLCO_CODPDT)}, {FieldThreatment(this.V0PDTV_OCORHIST)}, 0, {FieldThreatment(this.V0HCTA_NRCERTIF)}, {FieldThreatment(this.V0PARC_NRPARCEL)}, 8, 202, {FieldThreatment(this.V0SIST_DTMOVABE)}, {FieldThreatment(this.V0HCOB_DTVENCTO)}, '0' , {FieldThreatment(this.V0CMPT_VLPRMDIF)}, 0, 'VF0813B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PLCO_CODPDT { get; set; }
        public string V0PDTV_OCORHIST { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string V0CMPT_VLPRMDIF { get; set; }

        public static void Execute(M_1040_LOOP_DB_INSERT_1_Insert1 m_1040_LOOP_DB_INSERT_1_Insert1)
        {
            var ths = m_1040_LOOP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1040_LOOP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}