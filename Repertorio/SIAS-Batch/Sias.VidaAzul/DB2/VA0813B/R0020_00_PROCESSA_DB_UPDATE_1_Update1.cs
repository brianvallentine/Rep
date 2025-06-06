using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R0020_00_PROCESSA_DB_UPDATE_1_Update1 : QueryBasis<R0020_00_PROCESSA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO =  '{this.V0HCTA_SITUACAO}',
				NSAC =  '{this.V0FTCF_NSAC}',
				CODRET =  '{this.V0HCTA_CODRET}',
				OCORHIST =  '{this.V0HCTA_OCORHISTCOB}',
				CODUSU = 'VA0813B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0HCTA_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HCTA_NRPARCEL}'
				AND OCORRHISTCTA =  '{this.V0HCTA_OCORHISTCTA}'";

            return query;
        }
        public string V0HCTA_OCORHISTCOB { get; set; }
        public string V0HCTA_SITUACAO { get; set; }
        public string V0HCTA_CODRET { get; set; }
        public string V0FTCF_NSAC { get; set; }
        public string V0HCTA_OCORHISTCTA { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }

        public static void Execute(R0020_00_PROCESSA_DB_UPDATE_1_Update1 r0020_00_PROCESSA_DB_UPDATE_1_Update1)
        {
            var ths = r0020_00_PROCESSA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0020_00_PROCESSA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}