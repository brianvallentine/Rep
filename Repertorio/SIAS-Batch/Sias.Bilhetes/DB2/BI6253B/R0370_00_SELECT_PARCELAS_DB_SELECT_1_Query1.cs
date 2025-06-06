using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6253B
{
    public class R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.SIT_REGISTRO ,
            A.OCORR_HISTORICO ,
            B.COD_PRODUTO
            INTO :PARCELAS-SIT-REGISTRO ,
            :PARCELAS-OCORR-HISTORICO ,
            :ENDOSSOS-COD-PRODUTO
            FROM SEGUROS.PARCELAS A,
            SEGUROS.ENDOSSOS B
            WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND A.NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO
            AND A.NUM_PARCELA = :PARCELAS-NUM-PARCELA
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.SIT_REGISTRO 
							,
											A.OCORR_HISTORICO 
							,
											B.COD_PRODUTO
											FROM SEGUROS.PARCELAS A
							,
											SEGUROS.ENDOSSOS B
											WHERE A.NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND A.NUM_ENDOSSO = '{this.PARCELAS_NUM_ENDOSSO}'
											AND A.NUM_PARCELA = '{this.PARCELAS_NUM_PARCELA}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											WITH UR";

            return query;
        }
        public string PARCELAS_SIT_REGISTRO { get; set; }
        public string PARCELAS_OCORR_HISTORICO { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }

        public static R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1 Execute(R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1 r0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0370_00_SELECT_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCELAS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PARCELAS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}