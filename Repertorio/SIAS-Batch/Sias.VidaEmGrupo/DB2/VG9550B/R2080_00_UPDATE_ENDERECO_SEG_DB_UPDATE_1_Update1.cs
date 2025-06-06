using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9550B
{
    public class R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1 : QueryBasis<R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SEGURADOS_VGAP
				SET OCORR_ENDERECO =  '{this.WS_MAX_OCOREND}' ,
				OCORR_END_COBRAN =  '{this.WS_MAX_OCOREND}'
				WHERE  NUM_CERTIFICADO =  '{this.SEGURVGA_NUM_CERTIFICADO}'";

            return query;
        }
        public string WS_MAX_OCOREND { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1 r2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1)
        {
            var ths = r2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2080_00_UPDATE_ENDERECO_SEG_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}