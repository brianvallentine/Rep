using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1 : QueryBasis<R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0DIFPARCELVA
				SET NRPARCEL =  '{this.V0HISC_NRPARCEL}',
				CODOPER =  '{this.V3DIFP_CODOPER}',
				PRMDEVVG =  '{this.V0PARC_PRMVG}',
				PRMDEVAP =  '{this.V0PARC_PRMAP}',
				SITUACAO = '1'
				WHERE  NRCERTIF =  '{this.V0HISC_NRCERTIF}'
				AND NRPARCEL =  '{this.V0DIFP_NRPARCEL}'
				AND NRPARCELDIF =  '{this.V0DIFP_NRPARCELDIF}'
				AND CODOPER =  '{this.V0DIFP_CODOPER}'
				AND SITUACAO = ' '";

            return query;
        }
        public string V0HISC_NRPARCEL { get; set; }
        public string V3DIFP_CODOPER { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0DIFP_NRPARCELDIF { get; set; }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0DIFP_NRPARCEL { get; set; }
        public string V0DIFP_CODOPER { get; set; }

        public static void Execute(R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1 r1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1)
        {
            var ths = r1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}