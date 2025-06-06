using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0340B
{
    public class R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1 : QueryBasis<R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO = '3' ,
				DTVENCTO =  '{this.DTVENCTO}',
				NSAS =  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : $"{this.PARM_NSA}"))},
				NSL =  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : $"{this.NSL}"))}
				WHERE  NRCERTIF =  '{this.NRCERTIF}'
				AND NRPARCEL =  '{this.NRPARCEL}'
				AND OCORRHISTCTA =  '{this.OCORRHISTCTA}'";

            return query;
        }
        public string PARM_NSA { get; set; }
        public string SQL_NOT_NULL { get; set; }
        public string NSL { get; set; }
        public string DTVENCTO { get; set; }
        public string OCORRHISTCTA { get; set; }
        public string NRCERTIF { get; set; }
        public string NRPARCEL { get; set; }

        public static void Execute(R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1 r0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1)
        {
            var ths = r0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0320_00_PROCESSA_V0HCONTAVA_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}