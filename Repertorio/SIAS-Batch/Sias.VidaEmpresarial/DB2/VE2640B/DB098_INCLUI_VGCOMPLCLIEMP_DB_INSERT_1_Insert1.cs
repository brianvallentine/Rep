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
    public class DB098_INCLUI_VGCOMPLCLIEMP_DB_INSERT_1_Insert1 : QueryBasis<DB098_INCLUI_VGCOMPLCLIEMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_COMPL_CLI_EMP
            (COD_CLIENTE,
            DTA_FAT_ANUAL,
            VLR_FAT_ANUAL,
            DTA_CONSTITUICAO,
            COD_CNAE_ATIVIDADE)
            VALUES
            (:VG092-COD-CLIENTE,
            :VG092-DTA-FAT-ANUAL,
            :VG092-VLR-FAT-ANUAL,
            :VG092-DTA-CONSTITUICAO,
            :VG092-COD-CNAE-ATIVIDADE)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_COMPL_CLI_EMP (COD_CLIENTE, DTA_FAT_ANUAL, VLR_FAT_ANUAL, DTA_CONSTITUICAO, COD_CNAE_ATIVIDADE) VALUES ({FieldThreatment(this.VG092_COD_CLIENTE)}, {FieldThreatment(this.VG092_DTA_FAT_ANUAL)}, {FieldThreatment(this.VG092_VLR_FAT_ANUAL)}, {FieldThreatment(this.VG092_DTA_CONSTITUICAO)}, {FieldThreatment(this.VG092_COD_CNAE_ATIVIDADE)})";

            return query;
        }
        public string VG092_COD_CLIENTE { get; set; }
        public string VG092_DTA_FAT_ANUAL { get; set; }
        public string VG092_VLR_FAT_ANUAL { get; set; }
        public string VG092_DTA_CONSTITUICAO { get; set; }
        public string VG092_COD_CNAE_ATIVIDADE { get; set; }

        public static void Execute(DB098_INCLUI_VGCOMPLCLIEMP_DB_INSERT_1_Insert1 dB098_INCLUI_VGCOMPLCLIEMP_DB_INSERT_1_Insert1)
        {
            var ths = dB098_INCLUI_VGCOMPLCLIEMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB098_INCLUI_VGCOMPLCLIEMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}