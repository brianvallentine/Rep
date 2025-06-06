using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1813B
{
    public class R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1 : QueryBasis<R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET SITUACAO = '0' ,
				DTQITBCO =  '{this.V0PARC_DTVENCTO}'
				WHERE  NRCERTIF =  '{this.V0HCTA_NRCERTIF}'";

            return query;
        }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }

        public static void Execute(R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1 r1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1)
        {
            var ths = r1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}