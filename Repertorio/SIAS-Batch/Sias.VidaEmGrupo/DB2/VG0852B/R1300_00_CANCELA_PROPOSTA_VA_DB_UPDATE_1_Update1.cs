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
    public class R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1 : QueryBasis<R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET COD_USUARIO = 'VG0852B' ,
				COD_OPERACAO = 403 ,
				TIMESTAMP = CURRENT TIMESTAMP,
				SIT_REGISTRO = '4'
				WHERE  NUM_APOLICE =  '{this.PROPOVA_NUM_APOLICE}'
				AND COD_SUBGRUPO =  '{this.PROPOVA_COD_SUBGRUPO}'";

            return query;
        }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static void Execute(R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1 r1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1)
        {
            var ths = r1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_00_CANCELA_PROPOSTA_VA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}