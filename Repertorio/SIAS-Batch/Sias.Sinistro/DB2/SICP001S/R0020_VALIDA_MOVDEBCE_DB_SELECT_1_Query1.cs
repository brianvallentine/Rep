using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1 : QueryBasis<R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-COUNT
            FROM SEGUROS.MOVTO_DEBITOCC_CEF MO
            WHERE MO.NUM_APOLICE = :LK-SICPW001-NUM-APOLICE
            AND MO.NUM_ENDOSSO = :LK-SICPW001-NUM-ENDOSSO
            AND MO.NUM_PARCELA = :LK-SICPW001-NUM-PARCELA
            AND MO.NSAS = :LK-SICPW001-NSAS
            AND MO.SITUACAO_COBRANCA = :LK-SICPW001-SITUACAO-COBRANCA
            AND MO.COD_CONVENIO = :LK-SICPW001-COD-CONVENIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.MOVTO_DEBITOCC_CEF MO
											WHERE MO.NUM_APOLICE = '{this.LK_SICPW001_NUM_APOLICE}'
											AND MO.NUM_ENDOSSO = '{this.LK_SICPW001_NUM_ENDOSSO}'
											AND MO.NUM_PARCELA = '{this.LK_SICPW001_NUM_PARCELA}'
											AND MO.NSAS = '{this.LK_SICPW001_NSAS}'
											AND MO.SITUACAO_COBRANCA = '{this.LK_SICPW001_SITUACAO_COBRANCA}'
											AND MO.COD_CONVENIO = '{this.LK_SICPW001_COD_CONVENIO}'";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string LK_SICPW001_SITUACAO_COBRANCA { get; set; }
        public string LK_SICPW001_COD_CONVENIO { get; set; }
        public string LK_SICPW001_NUM_APOLICE { get; set; }
        public string LK_SICPW001_NUM_ENDOSSO { get; set; }
        public string LK_SICPW001_NUM_PARCELA { get; set; }
        public string LK_SICPW001_NSAS { get; set; }

        public static R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1 Execute(R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1 r0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1)
        {
            var ths = r0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}