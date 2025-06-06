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
    public class R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1 : QueryBasis<R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1>
    {

        private VF0853B_CDIFPAR CurrentOf { get; set; }

        public R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1(VF0853B_CDIFPAR currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0DIFPARCELVA
				SET NRPARCEL =  '{this.V0PROP_NRPARCEL}'
				WHERE
				(
					NRCERTIF = '{this.V0PROP_NRCERTIF}' AND NRPARCEL = 9999 AND SITUACAO = ' '
				)
				AND NRPARCEL {FieldThreatment(CurrentOf.V0DIFP_NRPARCEL, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string V0PROP_NRPARCEL { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1 r1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1)
        {
            var ths = r1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1510_00_MONTA_DIFERENCA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}