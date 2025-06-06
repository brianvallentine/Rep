using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class DB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1 : QueryBasis<DB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_COMPL_CLI_EMP
				SET VLR_FAT_ANUAL =  '{this.VG092_VLR_FAT_ANUAL}'
				, DTA_CONSTITUICAO =  '{this.VG092_DTA_CONSTITUICAO}'
				, COD_CNAE_ATIVIDADE =  '{this.VG092_COD_CNAE_ATIVIDADE}'
				WHERE COD_CLIENTE =  '{this.VG092_COD_CLIENTE}'
				AND DTA_FAT_ANUAL =  '{this.VG092_DTA_FAT_ANUAL}'";

            return query;
        }
        public string VG092_COD_CNAE_ATIVIDADE { get; set; }
        public string VG092_DTA_CONSTITUICAO { get; set; }
        public string VG092_VLR_FAT_ANUAL { get; set; }
        public string VG092_DTA_FAT_ANUAL { get; set; }
        public string VG092_COD_CLIENTE { get; set; }

        public static void Execute(DB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1 dB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1)
        {
            var ths = dB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB035_UPDATE_VG_COMPL_CLI_EMP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}