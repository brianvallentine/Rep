using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class R8000_PROPAUTOM_DB_UPDATE_2_Update1 : QueryBasis<R8000_PROPAUTOM_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PARCELVA
				SET PRMVG =  '{this.COBERP_PRMVG}',
				PRMAP =  '{this.COBERP_PRMAP}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.PROPVA_NRCERTIF}'
				AND NRPARCEL = 1";

            return query;
        }
        public string COBERP_PRMVG { get; set; }
        public string COBERP_PRMAP { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(R8000_PROPAUTOM_DB_UPDATE_2_Update1 r8000_PROPAUTOM_DB_UPDATE_2_Update1)
        {
            var ths = r8000_PROPAUTOM_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8000_PROPAUTOM_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}