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
    public class DB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1_Update1 : QueryBasis<DB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1_Update1>
    {

        private VE2640B_C2_TERMONIVEL CurrentOf { get; set; }

        public DB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1_Update1(VE2640B_C2_TERMONIVEL currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_TERMO_NIVEL
				SET VLR_PRM_INDIVIDUAL =  '{this.VGFUNCOB_VLR_PREMIO}',
				QTD_VIDAS =  '{this.VGTERNIV_QTD_VIDAS}'
				WHERE
				(
					NUM_PROPOSTA_SIVPF = '{this.VGTERNIV_NUM_PROPOSTA_SIVPF}' AND DTH_INI_VIGENCIA <= '{this.VGTERNIV_DTH_INI_VIGENCIA}' AND DTH_FIM_VIGENCIA >= '{this.VGTERNIV_DTH_INI_VIGENCIA}'
				)
				AND QTD_VIDAS {FieldThreatment(CurrentOf.VGTERNIV_NUM_PROPOSTA_SIVPF, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string VGFUNCOB_VLR_PREMIO { get; set; }
        public string VGTERNIV_QTD_VIDAS { get; set; }
        public string VGTERNIV_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGTERNIV_DTH_INI_VIGENCIA { get; set; }

        public static void Execute(DB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1_Update1 dB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1_Update1)
        {
            var ths = dB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB086_UPDATE_VG_TERMO_NIVEL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}