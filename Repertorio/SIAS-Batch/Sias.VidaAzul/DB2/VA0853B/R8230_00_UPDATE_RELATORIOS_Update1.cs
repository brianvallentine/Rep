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
    public class R8230_00_UPDATE_RELATORIOS_Update1 : QueryBasis<R8230_00_UPDATE_RELATORIOS_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RELATORIOS
				SET SITUACAO = '1'
				, PERI_FINAL =  '{this.V1SIST_DTMOVABE}'
				WHERE NRCERTIF =  '{this.V0PROP_NRCERTIF}'
				AND CODRELAT = 'PERDAO'
				AND SITUACAO = '0'";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R8230_00_UPDATE_RELATORIOS_Update1 r8230_00_UPDATE_RELATORIOS_Update1)
        {
            var ths = r8230_00_UPDATE_RELATORIOS_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8230_00_UPDATE_RELATORIOS_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}