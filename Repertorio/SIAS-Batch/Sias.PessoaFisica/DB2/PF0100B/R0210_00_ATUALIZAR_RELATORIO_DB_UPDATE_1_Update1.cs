using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0100B
{
    public class R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1 : QueryBasis<R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =
				 '{this.NUM_PROPOSTA_SIVPF}'
				AND SIT_REGISTRO =  '{this.RELATORI_SIT_REGISTRO}'
				AND IDE_SISTEMA =  '{this.RELATORI_IDE_SISTEMA}'
				AND COD_RELATORIO =  '{this.RELATORI_COD_RELATORIO}'";

            return query;
        }
        public string NUM_PROPOSTA_SIVPF { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_SIT_REGISTRO { get; set; }
        public string RELATORI_IDE_SISTEMA { get; set; }

        public static void Execute(R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1 r0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1)
        {
            var ths = r0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0210_00_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}