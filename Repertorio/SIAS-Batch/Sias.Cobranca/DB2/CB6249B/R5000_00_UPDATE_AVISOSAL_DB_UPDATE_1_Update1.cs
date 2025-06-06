using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6249B
{
    public class R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1 : QueryBasis<R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AVISOS_SALDOS
				SET SALDO_ATUAL =
				 '{this.AVISOSAL_SALDO_ATUAL}'
				WHERE  AGE_AVISO =
				 '{this.AVISOSAL_AGE_AVISO}'
				AND TIPO_SEGURO =
				 '{this.AVISOSAL_TIPO_SEGURO}'
				AND NUM_AVISO_CREDITO =
				 '{this.AVISOSAL_NUM_AVISO_CREDITO}'
				AND DATA_MOVIMENTO =
				 '{this.AVISOSAL_DATA_MOVIMENTO}'";

            return query;
        }
        public string AVISOSAL_SALDO_ATUAL { get; set; }
        public string AVISOSAL_NUM_AVISO_CREDITO { get; set; }
        public string AVISOSAL_DATA_MOVIMENTO { get; set; }
        public string AVISOSAL_TIPO_SEGURO { get; set; }
        public string AVISOSAL_AGE_AVISO { get; set; }

        public static void Execute(R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1 r5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1)
        {
            var ths = r5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}