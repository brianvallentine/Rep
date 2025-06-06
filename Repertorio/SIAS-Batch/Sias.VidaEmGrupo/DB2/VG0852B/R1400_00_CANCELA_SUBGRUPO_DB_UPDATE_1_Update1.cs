using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1 : QueryBasis<R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SUBGRUPOS_VGAP
				SET SIT_REGISTRO = '2'
				WHERE  NUM_APOLICE =  '{this.PROPOVA_NUM_APOLICE}'";

            return query;
        }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static void Execute(R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1 r1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1)
        {
            var ths = r1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_00_CANCELA_SUBGRUPO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}