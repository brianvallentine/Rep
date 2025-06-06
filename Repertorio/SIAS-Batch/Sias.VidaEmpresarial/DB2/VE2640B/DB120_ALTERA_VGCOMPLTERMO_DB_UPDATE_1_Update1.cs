using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB120_ALTERA_VGCOMPLTERMO_DB_UPDATE_1_Update1 : QueryBasis<DB120_ALTERA_VGCOMPLTERMO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_COMPL_TERMO
				SET DTH_LIBERACAO =  '{this.H_DT_MOV_ABERTO_2610}'
				WHERE  NUM_TERMO =  '{this.TERMOADE_NUM_TERMO}'";

            return query;
        }
        public string H_DT_MOV_ABERTO_2610 { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }

        public static void Execute(DB120_ALTERA_VGCOMPLTERMO_DB_UPDATE_1_Update1 dB120_ALTERA_VGCOMPLTERMO_DB_UPDATE_1_Update1)
        {
            var ths = dB120_ALTERA_VGCOMPLTERMO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB120_ALTERA_VGCOMPLTERMO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}