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
    public class R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1 : QueryBasis<R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_CLIENTES_MOVTO
				SET COD_USUARIO = 'VG9550B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_CLIENTE =  '{this.PROPOVA_COD_CLIENTE}'
				AND OCORR_ENDERECO =  '{this.PROPOVA_OCOREND}'";

            return query;
        }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }

        public static void Execute(R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1 r1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1)
        {
            var ths = r1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1060_00_UPDT_GE_CLIENTE_MOVTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}