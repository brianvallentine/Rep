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
    public class R0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1 : QueryBasis<R0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ARQUIVOS_SIVPF
				SET QTDE_REG_GER =  '{this.ARQSIVPF_QTDE_REG_GER}'
				WHERE  SIGLA_ARQUIVO = 'STASASSE'
				AND SISTEMA_ORIGEM =  '{this.ARQSIVPF_SISTEMA_ORIGEM}'
				AND NSAS_SIVPF =  '{this.ARQSIVPF_NSAS_SIVPF}'";

            return query;
        }
        public string ARQSIVPF_QTDE_REG_GER { get; set; }
        public string ARQSIVPF_SISTEMA_ORIGEM { get; set; }
        public string ARQSIVPF_NSAS_SIVPF { get; set; }

        public static void Execute(R0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1 r0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1)
        {
            var ths = r0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0010_00_FECHA_ARQUIVO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}