using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0634B
{
    public class R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1 : QueryBasis<R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ARQUIVOS_SIVPF
				SET
				QTDE_REG_GER =  '{this.ARQSIVPF_QTDE_REG_GER}'
				WHERE  SIGLA_ARQUIVO = 'STASASSE'
				AND SISTEMA_ORIGEM = 4
				AND NSAS_SIVPF =  '{this.ARQSIVPF_NSAS_SIVPF}'";

            return query;
        }
        public string ARQSIVPF_QTDE_REG_GER { get; set; }
        public string ARQSIVPF_NSAS_SIVPF { get; set; }

        public static void Execute(R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1 r0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1)
        {
            var ths = r0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}