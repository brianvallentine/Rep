using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1 : QueryBasis<R1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AVISOS_SALDOS
				SET SALDO_ATUAL = SALDO_ATUAL -  '{this.MOVIMCOB_VAL_TITULO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  BCO_AVISO =  '{this.MOVIMCOB_COD_BANCO}'
				AND AGE_AVISO =  '{this.MOVIMCOB_COD_AGENCIA}'
				AND NUM_AVISO_CREDITO =  '{this.MOVIMCOB_NUM_AVISO}'";

            return query;
        }
        public string MOVIMCOB_VAL_TITULO { get; set; }
        public string MOVIMCOB_COD_AGENCIA { get; set; }
        public string MOVIMCOB_COD_BANCO { get; set; }
        public string MOVIMCOB_NUM_AVISO { get; set; }

        public static void Execute(R1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1 r1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1)
        {
            var ths = r1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}