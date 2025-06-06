using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P22400_00_ATUALIZACOES_DB_UPDATE_3_Update1 : QueryBasis<P22400_00_ATUALIZACOES_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AVISOS_SALDOS
				SET SALDO_ATUAL =  '{this.AVISOSAL_SALDO_ATUAL}'
				WHERE  AGE_AVISO =  '{this.FOLLOUP_AGE_AVISO}'
				AND TIPO_SEGURO =  '{this.FOLLOUP_TIPO_SEGURO}'
				AND NUM_AVISO_CREDITO =  '{this.FOLLOUP_NUM_AVISO_CREDITO}'";

            return query;
        }
        public string AVISOSAL_SALDO_ATUAL { get; set; }
        public string FOLLOUP_NUM_AVISO_CREDITO { get; set; }
        public string FOLLOUP_TIPO_SEGURO { get; set; }
        public string FOLLOUP_AGE_AVISO { get; set; }

        public static void Execute(P22400_00_ATUALIZACOES_DB_UPDATE_3_Update1 p22400_00_ATUALIZACOES_DB_UPDATE_3_Update1)
        {
            var ths = p22400_00_ATUALIZACOES_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P22400_00_ATUALIZACOES_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}