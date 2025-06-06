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
    public class R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1 : QueryBasis<R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1>
    {

        private VF0851B_CPARDIF CurrentOf { get; set; }

        public R1760_00_APROPRIA_DIFERENCA_DB_UPDATE_1_Update1(VF0851B_CPARDIF currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0DIFPARCELVA
				SET NRPARCEL =  '{this.V0PARC_NRPARCEL}',
				PRMDIFVG =  '{this.V0PARC_PRMVG}',
				PRMDIFAP =  '{this.V0PARC_PRMAP}',
				SITUACAO = '1'
				WHERE
				(
					NRCERTIF = '{this.V0PROP_NRCERTIF}' AND NRPARCEL = 9999 AND CODOPER >= 600 AND CODOPER <= 699 AND SITUACAO = ' '
				)
				AND SITUACAO {FieldThreatment(CurrentOf.V0DIFP_NRPARCEL, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

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