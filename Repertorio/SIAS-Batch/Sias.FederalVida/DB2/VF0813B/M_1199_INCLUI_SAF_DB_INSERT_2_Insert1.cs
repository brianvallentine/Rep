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
    public class M_1199_INCLUI_SAF_DB_INSERT_2_Insert1 : QueryBasis<M_1199_INCLUI_SAF_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTREPSAF
            VALUES (:V0PROP-CODCLIEN,
            :V0RSAF-DTREFER,
            :V0HCTA-NRCERTIF,
            :V0PARC-NRPARCEL,
            0,
            :V0SAFC-VLCUSTSAF,
            102,
            '0' ,
            '0' ,
            0,
            0,
            'VF0813B' ,
            CURRENT TIMESTAMP,
            :V0PARC-DTVENCTO:VIND-DTMOVTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTREPSAF VALUES ({FieldThreatment(this.V0PROP_CODCLIEN)}, {FieldThreatment(this.V0RSAF_DTREFER)}, {FieldThreatment(this.V0HCTA_NRCERTIF)}, {FieldThreatment(this.V0PARC_NRPARCEL)}, 0, {FieldThreatment(this.V0SAFC_VLCUSTSAF)}, 102, '0' , '0' , 0, 0, 'VF0813B' , CURRENT TIMESTAMP,  {FieldThreatment((this.VIND_DTMOVTO?.ToInt() == -1 ? null : this.V0PARC_DTVENCTO))})";

            return query;
        }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0RSAF_DTREFER { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0SAFC_VLCUSTSAF { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string VIND_DTMOVTO { get; set; }

        public static void Execute(M_1199_INCLUI_SAF_DB_INSERT_2_Insert1 m_1199_INCLUI_SAF_DB_INSERT_2_Insert1)
        {
            var ths = m_1199_INCLUI_SAF_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1199_INCLUI_SAF_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}