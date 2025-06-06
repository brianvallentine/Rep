using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP03B
{
    public class R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1 : QueryBasis<R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_REQUISICAO
            INTO
            :MOVDEBCE-NUM-REQUISICAO
            FROM SEGUROS.MOVTO_DEBITOCC_CEF
            WHERE NUM_APOLICE = :GE094-NUM-APOLICE
            AND NUM_ENDOSSO = :GE094-NUM-ENDOSSO
            AND NUM_PARCELA = :GE094-NUM-PARCELA
            AND COD_CONVENIO = :GE094-COD-CONVENIO
            AND NSAS = :GE094-NSAS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_REQUISICAO
											FROM SEGUROS.MOVTO_DEBITOCC_CEF
											WHERE NUM_APOLICE = '{this.GE094_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.GE094_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.GE094_NUM_PARCELA}'
											AND COD_CONVENIO = '{this.GE094_COD_CONVENIO}'
											AND NSAS = '{this.GE094_NSAS}'";

            return query;
        }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string GE094_COD_CONVENIO { get; set; }
        public string GE094_NUM_APOLICE { get; set; }
        public string GE094_NUM_ENDOSSO { get; set; }
        public string GE094_NUM_PARCELA { get; set; }
        public string GE094_NSAS { get; set; }

        public static R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1 Execute(R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1 r1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1)
        {
            var ths = r1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1();
            var i = 0;
            dta.MOVDEBCE_NUM_REQUISICAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}