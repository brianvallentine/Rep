using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6254B
{
    public class R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE ,
            A.NUM_ENDOSSO ,
            A.NUM_PARCELA ,
            A.SIT_REGISTRO ,
            B.COD_PRODUTO ,
            B.QTD_PARCELAS
            INTO :PARCELAS-NUM-APOLICE ,
            :PARCELAS-NUM-ENDOSSO ,
            :PARCELAS-NUM-PARCELA ,
            :PARCELAS-SIT-REGISTRO ,
            :ENDOSSOS-COD-PRODUTO ,
            :ENDOSSOS-QTD-PARCELAS
            FROM SEGUROS.PARCELAS A,
            SEGUROS.ENDOSSOS B
            WHERE A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            AND A.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO
            AND A.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA
            AND A.SIT_REGISTRO = '0'
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE 
							,
											A.NUM_ENDOSSO 
							,
											A.NUM_PARCELA 
							,
											A.SIT_REGISTRO 
							,
											B.COD_PRODUTO 
							,
											B.QTD_PARCELAS
											FROM SEGUROS.PARCELAS A
							,
											SEGUROS.ENDOSSOS B
											WHERE A.NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.MOVDEBCE_NUM_ENDOSSO}'
											AND A.NUM_PARCELA = '{this.MOVDEBCE_NUM_PARCELA}'
											AND A.SIT_REGISTRO = '0'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }
        public string PARCELAS_SIT_REGISTRO { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_QTD_PARCELAS { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }

        public static R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCELAS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.PARCELAS_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PARCELAS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_QTD_PARCELAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}