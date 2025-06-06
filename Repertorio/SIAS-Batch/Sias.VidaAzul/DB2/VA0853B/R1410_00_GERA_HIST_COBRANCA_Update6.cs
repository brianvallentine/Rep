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
    public class R1410_00_GERA_HIST_COBRANCA_Update6 : QueryBasis<R1410_00_GERA_HIST_COBRANCA_Update6>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_LANC_CTA
				SET SIT_REGISTRO = '2'
				WHERE NUM_CERTIFICADO =  '{this.V0PROP_NRCERTIF}'
				AND NUM_PARCELA =  '{this.V0RELA_NRPARCEL}'
				AND SIT_REGISTRO <> '1'";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0RELA_NRPARCEL { get; set; }

        public static void Execute(R1410_00_GERA_HIST_COBRANCA_Update6 r1410_00_GERA_HIST_COBRANCA_Update6)
        {
            var ths = r1410_00_GERA_HIST_COBRANCA_Update6;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1410_00_GERA_HIST_COBRANCA_Update6 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}