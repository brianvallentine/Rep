using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0095B
{
    public class R0020_10_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<R0020_10_UPDATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVIMENTO
				SET COD_FONTE =  '{this.V0SEG_FONTE}',
				NUM_PROPOSTA =  '{this.PROPAUTOM}'
				WHERE  COD_FONTE =  '{this.MCOD_FONTE}'
				AND NUM_PROPOSTA =  '{this.MNUM_PROPOSTA}'
				AND TIPO_SEGURADO=  '{this.MTIPO_SEGURADO}'";

            return query;
        }
        public string V0SEG_FONTE { get; set; }
        public string PROPAUTOM { get; set; }
        public string MTIPO_SEGURADO { get; set; }
        public string MNUM_PROPOSTA { get; set; }
        public string MCOD_FONTE { get; set; }

        public static void Execute(R0020_10_UPDATE_DB_UPDATE_1_Update1 r0020_10_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = r0020_10_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0020_10_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}