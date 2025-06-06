using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTFASESS
{
    public class R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1 : QueryBasis<R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.SI_SINISTRO_FASE
            WHERE COD_FONTE = :SISINFAS-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SISINFAS-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SISINFAS-DAC-PROTOCOLO-SINI
            AND COD_FASE = :SISINFAS-COD-FASE
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.SI_SINISTRO_FASE
				WHERE COD_FONTE = '{this.SISINFAS_COD_FONTE}'
				AND NUM_PROTOCOLO_SINI = '{this.SISINFAS_NUM_PROTOCOLO_SINI}'
				AND DAC_PROTOCOLO_SINI = '{this.SISINFAS_DAC_PROTOCOLO_SINI}'
				AND COD_FASE = '{this.SISINFAS_COD_FASE}'";

            return query;
        }
        public string SISINFAS_COD_FONTE { get; set; }
        public string SISINFAS_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINFAS_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINFAS_COD_FASE { get; set; }

        public static void Execute(R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1 r3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1)
        {
            var ths = r3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}