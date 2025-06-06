using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0853B
{
    public class R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1 : QueryBasis<R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0DIFPARCELVA
				SET SITUACAO = '1' ,
				NRPARCEL =  '{this.V0PROP_NRPARCEL}'
				WHERE  NRCERTIF =  '{this.V0PROP_NRCERTIF}'
				AND NRPARCEL =  '{this.V0PROP_NRPARCEL}'
				AND NRPARCELDIF =  '{this.V0COMP_NRPARCEL}'
				AND CODOPER =  '{this.V0COMP_CODOPER}'
				AND PRMDIFVG =  '{this.V0COMP_PRMDIFVG}'
				AND PRMDIFAP =  '{this.V0COMP_PRMDIFAP}'";

            return query;
        }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0COMP_NRPARCEL { get; set; }
        public string V0COMP_PRMDIFVG { get; set; }
        public string V0COMP_PRMDIFAP { get; set; }
        public string V0COMP_CODOPER { get; set; }

        public static void Execute(R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1 r1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1)
        {
            var ths = r1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}