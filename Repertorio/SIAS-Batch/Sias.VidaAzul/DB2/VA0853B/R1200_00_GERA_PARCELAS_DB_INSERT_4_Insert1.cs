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
    public class R1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1 : QueryBasis<R1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0PARCELCAPVG
            VALUES (:V0PROP-NRCERTIF,
            :WHOST-PARCELCAP,
            :V0PROP-DTVENCTO,
            :V0COBP-VLCUSTCAP,
            :V0COBP-VLCUSTCAP,
            '3' ,
            '0' ,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PARCELCAPVG VALUES ({FieldThreatment(this.V0PROP_NRCERTIF)}, {FieldThreatment(this.WHOST_PARCELCAP)}, {FieldThreatment(this.V0PROP_DTVENCTO)}, {FieldThreatment(this.V0COBP_VLCUSTCAP)}, {FieldThreatment(this.V0COBP_VLCUSTCAP)}, '3' , '0' , 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string WHOST_PARCELCAP { get; set; }
        public string V0PROP_DTVENCTO { get; set; }
        public string V0COBP_VLCUSTCAP { get; set; }

        public static void Execute(R1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1 r1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1)
        {
            var ths = r1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}