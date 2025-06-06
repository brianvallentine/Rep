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
    public class R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1 : QueryBasis<R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(DISTINCT SL.NUM_APOL_SINISTRO),0)
            INTO :SIMOLOT1-QTD-SINI-AVISADO
            FROM SEGUROS.SINI_LOTERICO01 SL
            ,SEGUROS.SINISTRO_MESTRE M
            WHERE SL.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF
            AND SL.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            AND SL.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(DISTINCT SL.NUM_APOL_SINISTRO)
							,0)
											FROM SEGUROS.SINI_LOTERICO01 SL
											,SEGUROS.SINISTRO_MESTRE M
											WHERE SL.COD_LOT_CEF = '{this.LOTERI01_COD_LOT_CEF}'
											AND SL.COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											AND SL.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO";

            return query;
        }
        public string SIMOLOT1_QTD_SINI_AVISADO { get; set; }
        public string LOTERI01_COD_LOT_FENAL { get; set; }
        public string LOTERI01_COD_LOT_CEF { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1 Execute(R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1 r1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1)
        {
            var ths = r1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1080_INCLUI_SIMOLOT1_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIMOLOT1_QTD_SINI_AVISADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}