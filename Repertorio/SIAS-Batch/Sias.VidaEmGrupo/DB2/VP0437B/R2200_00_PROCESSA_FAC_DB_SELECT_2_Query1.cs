using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1 : QueryBasis<R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_COMPRA
            INTO :MOEDACOT-VAL-COMPRA
            FROM SEGUROS.MOEDAS_COTACAO
            WHERE COD_MOEDA =
            :SEGVGAPH-COD-MOEDA-PRM
            AND DATA_INIVIGENCIA <=
            :SEGVGAPH-DATA-MOVIMENTO
            AND DATA_TERVIGENCIA >=
            :SEGVGAPH-DATA-MOVIMENTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_COMPRA
											FROM SEGUROS.MOEDAS_COTACAO
											WHERE COD_MOEDA =
											'{this.SEGVGAPH_COD_MOEDA_PRM}'
											AND DATA_INIVIGENCIA <=
											'{this.SEGVGAPH_DATA_MOVIMENTO}'
											AND DATA_TERVIGENCIA >=
											'{this.SEGVGAPH_DATA_MOVIMENTO}'";

            return query;
        }
        public string MOEDACOT_VAL_COMPRA { get; set; }
        public string SEGVGAPH_DATA_MOVIMENTO { get; set; }
        public string SEGVGAPH_COD_MOEDA_PRM { get; set; }

        public static R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1 Execute(R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1 r2200_00_PROCESSA_FAC_DB_SELECT_2_Query1)
        {
            var ths = r2200_00_PROCESSA_FAC_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1();
            var i = 0;
            dta.MOEDACOT_VAL_COMPRA = result[i++].Value?.ToString();
            return dta;
        }

    }
}