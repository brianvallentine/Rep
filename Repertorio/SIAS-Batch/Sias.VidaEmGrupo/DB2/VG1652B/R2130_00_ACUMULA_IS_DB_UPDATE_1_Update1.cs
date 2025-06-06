using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1652B
{
    public class R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1 : QueryBasis<R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.HIST_CONT_PARCELVA
				SET DTFATUR =  '{this.WHOST_DATA_FAT_FIM}',
				NUM_ENDOSSO =  '{this.HISCONPA_NUM_ENDOSSO}',
				SIT_REGISTRO = '1'
				WHERE 
				NUM_CERTIFICADO =  '{this.SEGURVGA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.WHOST_NUM_PARCELA}'
				AND COD_OPERACAO BETWEEN 200 AND 299
				AND SIT_REGISTRO = '9'
				AND DTFATUR IS NULL";

            return query;
        }
        public string HISCONPA_NUM_ENDOSSO { get; set; }
        public string WHOST_DATA_FAT_FIM { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }
        public string WHOST_NUM_PARCELA { get; set; }

        public static void Execute(R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1 r2130_00_ACUMULA_IS_DB_UPDATE_1_Update1)
        {
            var ths = r2130_00_ACUMULA_IS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2130_00_ACUMULA_IS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}