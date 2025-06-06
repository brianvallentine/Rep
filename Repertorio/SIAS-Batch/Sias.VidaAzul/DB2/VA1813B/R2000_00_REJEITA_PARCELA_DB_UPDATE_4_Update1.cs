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
    public class R2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1 : QueryBasis<R2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO = '2'
				WHERE  NRCERTIF =  '{this.V0HCTA_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HCTA_NRPARCEL}'
				AND OCORRHISTCTA =  '{this.V0HCTA_OCORHISTCTA}'";

            return query;
        }
        public string V0HCTA_OCORHISTCTA { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }

        public static void Execute(R2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1 r2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1)
        {
            var ths = r2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}