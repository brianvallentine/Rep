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
    public class M_0020_PROCESSA_DB_INSERT_1_Insert1 : QueryBasis<M_0020_PROCESSA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCONTABILVA
            VALUES (:V0HCTA-NRCERTIF,
            :V0HCOB-NRPARCEL,
            :V0HCOB-NRTIT,
            :V0HCOB-OCORHIST,
            :V0PROP-NUM-APOLICE,
            :V0PROP-CODSUBES,
            :V0PROP-FONTE,
            0,
            :V0HCTB-PRMVG,
            :V0HCTB-PRMAP,
            :V0HCOB-DTVENCTO,
            '0' ,
            202,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES ({FieldThreatment(this.V0HCTA_NRCERTIF)}, {FieldThreatment(this.V0HCOB_NRPARCEL)}, {FieldThreatment(this.V0HCOB_NRTIT)}, {FieldThreatment(this.V0HCOB_OCORHIST)}, {FieldThreatment(this.V0PROP_NUM_APOLICE)}, {FieldThreatment(this.V0PROP_CODSUBES)}, {FieldThreatment(this.V0PROP_FONTE)}, 0, {FieldThreatment(this.V0HCTB_PRMVG)}, {FieldThreatment(this.V0HCTB_PRMAP)}, {FieldThreatment(this.V0HCOB_DTVENCTO)}, '0' , 202, CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0HCTB_PRMVG { get; set; }
        public string V0HCTB_PRMAP { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }

        public static void Execute(M_0020_PROCESSA_DB_INSERT_1_Insert1 m_0020_PROCESSA_DB_INSERT_1_Insert1)
        {
            var ths = m_0020_PROCESSA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0020_PROCESSA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}