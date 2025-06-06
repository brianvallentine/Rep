using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1139B
{
    public class R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 : QueryBasis<R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RCAPCOMP
				SET SITUACAO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRRCAP =  '{this.V1RCAC_NRRCAP}'
				AND NRRCAPCO =  '{this.V1RCAC_NRRCAPCO}'
				AND OPERACAO =  '{this.V1RCAC_OPERACAO}'
				AND DTMOVTO =  '{this.V1RCAC_DTMOVTO}'
				AND HORAOPER =  '{this.V1RCAC_HORAOPER}'";

            return query;
        }
        public string V1RCAC_NRRCAPCO { get; set; }
        public string V1RCAC_OPERACAO { get; set; }
        public string V1RCAC_HORAOPER { get; set; }
        public string V1RCAC_DTMOVTO { get; set; }
        public string V1RCAC_NRRCAP { get; set; }

        public static void Execute(R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1)
        {
            var ths = r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}