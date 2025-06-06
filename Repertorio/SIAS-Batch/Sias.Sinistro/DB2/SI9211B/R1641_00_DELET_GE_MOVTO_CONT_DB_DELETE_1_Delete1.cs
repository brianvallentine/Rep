using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1 : QueryBasis<R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.GE_MOVTO_CONTA
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.GE_MOVTO_CONTA
				WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
				AND NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
				AND NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'";

            return query;
        }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static void Execute(R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1 r1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1)
        {
            var ths = r1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}