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
    public class R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1 : QueryBasis<R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.VG_FOLLOW_UP
				SET
				NUM_PARCELA_USADA =  '{this.V0HCTA_NRPARCEL}',
				STA_PROCESSAMENTO = 'P' ,
				COD_USUARIO = 'VA0813B' ,
				DTH_ATUALIZACAO = CURRENT TIMESTAMP
				WHERE 
				NUM_CERTIFICADO =  '{this.VGFOLLOW_NUM_CERTIFICADO}'
				AND NUM_NOSSA_FITA =  '{this.VGFOLLOW_NUM_NOSSA_FITA}'
				AND NUM_LANCAMENTO =  '{this.VGFOLLOW_NUM_LANCAMENTO}'";

            return query;
        }
        public string V0HCTA_NRPARCEL { get; set; }
        public string VGFOLLOW_NUM_CERTIFICADO { get; set; }
        public string VGFOLLOW_NUM_NOSSA_FITA { get; set; }
        public string VGFOLLOW_NUM_LANCAMENTO { get; set; }

        public static void Execute(R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1 r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1)
        {
            var ths = r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}