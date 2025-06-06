using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1 : QueryBasis<R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0EVENTOSVF
            VALUES (:V0PLAC-CODPDT,
            :V0PDVF-OCORHIST,
            0,
            :V0EVEN-NRCERTIF,
            :V0EVEN-NRPARCEL,
            :V0EVEN-CODEVEN,
            :V0EVEN-CODOPER,
            :V1SIST-DTMOVABE,
            :V0EVEN-DTVENCTO,
            '0' ,
            :V0EVEN-VLPRMTOT,
            0,
            'VF0851B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0EVENTOSVF VALUES ({FieldThreatment(this.V0PLAC_CODPDT)}, {FieldThreatment(this.V0PDVF_OCORHIST)}, 0, {FieldThreatment(this.V0EVEN_NRCERTIF)}, {FieldThreatment(this.V0EVEN_NRPARCEL)}, {FieldThreatment(this.V0EVEN_CODEVEN)}, {FieldThreatment(this.V0EVEN_CODOPER)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V0EVEN_DTVENCTO)}, '0' , {FieldThreatment(this.V0EVEN_VLPRMTOT)}, 0, 'VF0851B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0PLAC_CODPDT { get; set; }
        public string V0PDVF_OCORHIST { get; set; }
        public string V0EVEN_NRCERTIF { get; set; }
        public string V0EVEN_NRPARCEL { get; set; }
        public string V0EVEN_CODEVEN { get; set; }
        public string V0EVEN_CODOPER { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0EVEN_DTVENCTO { get; set; }
        public string V0EVEN_VLPRMTOT { get; set; }

        public static void Execute(R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1 r2100_00_GERA_EVENTO_DB_INSERT_1_Insert1)
        {
            var ths = r2100_00_GERA_EVENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_GERA_EVENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}