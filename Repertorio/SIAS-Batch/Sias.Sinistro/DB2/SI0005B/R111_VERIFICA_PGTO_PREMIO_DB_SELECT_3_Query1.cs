using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1 : QueryBasis<R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-PAGTO
            FROM
            SEGUROS.ENDOSSOS E,
            SEGUROS.MOVTO_DEBITOCC_CEF C
            WHERE
            E.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND
            C.NUM_APOLICE = E.NUM_APOLICE AND
            E.NUM_ENDOSSO = 0 AND
            C.NUM_ENDOSSO = 0 AND
            C.SITUACAO_COBRANCA IN ( '1' , '2' , ' ' ) AND
            YEAR(C.DATA_VENCIMENTO) =
            :HOST-ANO-OCORRENCIA AND
            ((E.QTD_PARCELAS = C.NUM_PARCELA) OR
            (C.DATA_VENCIMENTO >=
            (SELECT DATA_CALENDARIO - 1 MONTH
            FROM SEGUROS.CALENDARIO
            WHERE DATA_CALENDARIO =
            :HOST-DATA-OCORRENCIA)))
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM
											SEGUROS.ENDOSSOS E
							,
											SEGUROS.MOVTO_DEBITOCC_CEF C
											WHERE
											E.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}' AND
											C.NUM_APOLICE = E.NUM_APOLICE AND
											E.NUM_ENDOSSO = 0 AND
											C.NUM_ENDOSSO = 0 AND
											C.SITUACAO_COBRANCA IN ( '1' 
							, '2' 
							, ' ' ) AND
											YEAR(C.DATA_VENCIMENTO) =
											'{this.HOST_ANO_OCORRENCIA}' AND
											((E.QTD_PARCELAS = C.NUM_PARCELA) OR
											(C.DATA_VENCIMENTO >=
											(SELECT DATA_CALENDARIO - 1 MONTH
											FROM SEGUROS.CALENDARIO
											WHERE DATA_CALENDARIO =
											'{this.HOST_DATA_OCORRENCIA}')))
											WITH UR";

            return query;
        }
        public string HOST_PAGTO { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }
        public string HOST_DATA_OCORRENCIA { get; set; }
        public string HOST_ANO_OCORRENCIA { get; set; }

        public static R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1 Execute(R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1 r111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1)
        {
            var ths = r111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3_Query1();
            var i = 0;
            dta.HOST_PAGTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}