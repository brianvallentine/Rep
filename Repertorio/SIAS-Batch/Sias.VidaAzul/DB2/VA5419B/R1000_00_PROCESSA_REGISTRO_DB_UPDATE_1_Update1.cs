using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTREPSAF
				SET SITUACAO = '1'
				WHERE  CODCLIEN =  '{this.V0RSAF_CODCLIEN}'
				AND DTREF =  '{this.V0RSAF_DTREF}'
				AND CODOPER =  '{this.V0RSAF_CODOPER}'
				AND NRCERTIF =  '{this.V0RSAF_NRCERTIF}'
				AND SITUACAO = '0'";

            return query;
        }
        public string V0RSAF_CODCLIEN { get; set; }
        public string V0RSAF_NRCERTIF { get; set; }
        public string V0RSAF_CODOPER { get; set; }
        public string V0RSAF_DTREF { get; set; }

        public static void Execute(R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}