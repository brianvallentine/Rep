using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0016B
{
    public class R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1 : QueryBasis<R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_ACOPLADO
				SET
				STA_ACOPLADO = 9
				, COD_USUARIO = 'VG0016B'
				, NOM_PROGRAMA = 'INATIVO'
				, DTH_CADASTRAMENTO = CURRENT TIMESTAMP
				WHERE  IDE_SISTEMA =  '{this.VG135_IDE_SISTEMA}'
				AND NUM_CERTIFICADO =  '{this.VG135_NUM_CERTIFICADO}'
				AND COD_PRODUTO =  '{this.VG135_COD_PRODUTO}'
				AND COD_PLANO =  '{this.VG135_COD_PLANO}'
				AND STA_ACOPLADO = 7";

            return query;
        }
        public string VG135_NUM_CERTIFICADO { get; set; }
        public string VG135_IDE_SISTEMA { get; set; }
        public string VG135_COD_PRODUTO { get; set; }
        public string VG135_COD_PLANO { get; set; }

        public static void Execute(R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1 r0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1)
        {
            var ths = r0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}