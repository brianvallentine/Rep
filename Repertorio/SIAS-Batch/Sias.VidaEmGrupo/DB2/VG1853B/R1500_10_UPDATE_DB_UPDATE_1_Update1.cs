using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1853B
{
    public class R1500_10_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<R1500_10_UPDATE_DB_UPDATE_1_Update1>
    {

        private VG1853B_CDIFPAR CurrentOf { get; set; }

        public R1500_10_UPDATE_DB_UPDATE_1_Update1(VG1853B_CDIFPAR currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0DIFPARCELVA
				SET NRPARCEL =  '{this.V0PROP_NRPARCEL}',
				CODOPER =  '{this.V3DIFP_CODOPER}'
				WHERE
				(
					NRCERTIF = '{this.V0PROP_NRCERTIF}' AND DTVENCTO <= '{this.V0PROP_DTVENCTO}' AND SITUACAO = ' '
				)
				AND PRMDIFAP {FieldThreatment(CurrentOf.V0DIFP_NRPARCEL, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string V0PROP_NRPARCEL { get; set; }
        public string V3DIFP_CODOPER { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_DTVENCTO { get; set; }

        public static void Execute(R1500_10_UPDATE_DB_UPDATE_1_Update1 r1500_10_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = r1500_10_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1500_10_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}