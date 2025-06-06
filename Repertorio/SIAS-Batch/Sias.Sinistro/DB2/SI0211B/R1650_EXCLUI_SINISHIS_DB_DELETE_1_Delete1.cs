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
    public class R1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1 : QueryBasis<R1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.SINISTRO_HISTORICO
            WHERE COD_OPERACAO = :H-SINISHIS-COD-OPERACAO
            AND NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = :HOST-MIN-OCORR-HISTORICO
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.SINISTRO_HISTORICO
				WHERE COD_OPERACAO = '{this.H_SINISHIS_COD_OPERACAO}'
				AND NUM_APOL_SINISTRO = '{this.SI111_NUM_APOL_SINISTRO}'
				AND OCORR_HISTORICO = '{this.HOST_MIN_OCORR_HISTORICO}'";

            return query;
        }
        public string H_SINISHIS_COD_OPERACAO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string HOST_MIN_OCORR_HISTORICO { get; set; }

        public static void Execute(R1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1 r1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1)
        {
            var ths = r1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}