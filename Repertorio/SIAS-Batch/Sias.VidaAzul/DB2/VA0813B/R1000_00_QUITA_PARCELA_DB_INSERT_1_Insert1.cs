using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1 : QueryBasis<R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCONTABILVA
            VALUES (:V0HCTA-NRCERTIF,
            :V0HCTA-NRPARCEL,
            :V0HCOB-NRTIT,
            :V0HCOB-OCORHIST,
            :V0PROP-NUM-APOLICE,
            :V0PROP-CODSUBES,
            :V0PROP-FONTE,
            0,
            :V0HCTVA-PRMVG,
            :V0HCTVA-PRMAP,
            :V0SIST-DTMOVABE,
            '0' ,
            :V0HCTB-CODOPER,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES ({FieldThreatment(this.V0HCTA_NRCERTIF)}, {FieldThreatment(this.V0HCTA_NRPARCEL)}, {FieldThreatment(this.V0HCOB_NRTIT)}, {FieldThreatment(this.V0HCOB_OCORHIST)}, {FieldThreatment(this.V0PROP_NUM_APOLICE)}, {FieldThreatment(this.V0PROP_CODSUBES)}, {FieldThreatment(this.V0PROP_FONTE)}, 0, {FieldThreatment(this.V0HCTVA_PRMVG)}, {FieldThreatment(this.V0HCTVA_PRMAP)}, {FieldThreatment(this.V0SIST_DTMOVABE)}, '0' , {FieldThreatment(this.V0HCTB_CODOPER)}, CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0HCTVA_PRMVG { get; set; }
        public string V0HCTVA_PRMAP { get; set; }
        public string V0SIST_DTMOVABE { get; set; }
        public string V0HCTB_CODOPER { get; set; }

        public static void Execute(R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1 r1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1)
        {
            var ths = r1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}