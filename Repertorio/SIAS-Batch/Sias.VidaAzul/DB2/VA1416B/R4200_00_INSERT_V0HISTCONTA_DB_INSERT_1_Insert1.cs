using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1416B
{
    public class R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1 : QueryBasis<R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCONTABILVA
            VALUES (:V0HCOB-NRCERTIF ,
            :V0HCOB-NRPARCEL ,
            :V0HCOB-NRTIT ,
            :V0HCOB-OCORHIST ,
            :V0PROP-APOLICE ,
            :V0PROP-CODSUBES ,
            :V0PROP-FONTE ,
            0 ,
            :V0PARC-PRMVG ,
            :V0PARC-PRMAP ,
            :V0HCOB-DTVENCTO ,
            ' ' ,
            1000 ,
            CURRENT TIMESTAMP,
            :V0RELA-DTREFER)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES ({FieldThreatment(this.V0HCOB_NRCERTIF)} , {FieldThreatment(this.V0HCOB_NRPARCEL)} , {FieldThreatment(this.V0HCOB_NRTIT)} , {FieldThreatment(this.V0HCOB_OCORHIST)} , {FieldThreatment(this.V0PROP_APOLICE)} , {FieldThreatment(this.V0PROP_CODSUBES)} , {FieldThreatment(this.V0PROP_FONTE)} , 0 , {FieldThreatment(this.V0PARC_PRMVG)} , {FieldThreatment(this.V0PARC_PRMAP)} , {FieldThreatment(this.V0HCOB_DTVENCTO)} , ' ' , 1000 , CURRENT TIMESTAMP, {FieldThreatment(this.V0RELA_DTREFER)})";

            return query;
        }
        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_OCORHIST { get; set; }
        public string V0PROP_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_FONTE { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string V0RELA_DTREFER { get; set; }

        public static void Execute(R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1 r4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1)
        {
            var ths = r4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}