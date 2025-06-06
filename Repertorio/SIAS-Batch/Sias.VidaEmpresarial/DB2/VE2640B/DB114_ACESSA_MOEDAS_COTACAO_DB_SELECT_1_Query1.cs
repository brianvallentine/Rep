using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1 : QueryBasis<DB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_COMPRA
            INTO :MOEDACOT-VAL-COMPRA
            FROM SEGUROS.MOEDAS_COTACAO
            WHERE COD_MOEDA = :ENDOSSOS-COD-MOEDA-PRM
            AND DATA_INIVIGENCIA <= :VGSOLFAT-DTVENCTO-FATURA
            AND DATA_TERVIGENCIA >= :VGSOLFAT-DTVENCTO-FATURA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VAL_COMPRA
											FROM SEGUROS.MOEDAS_COTACAO
											WHERE COD_MOEDA = '{this.ENDOSSOS_COD_MOEDA_PRM}'
											AND DATA_INIVIGENCIA <= '{this.VGSOLFAT_DTVENCTO_FATURA}'
											AND DATA_TERVIGENCIA >= '{this.VGSOLFAT_DTVENCTO_FATURA}'
											WITH UR";

            return query;
        }
        public string MOEDACOT_VAL_COMPRA { get; set; }
        public string VGSOLFAT_DTVENCTO_FATURA { get; set; }
        public string ENDOSSOS_COD_MOEDA_PRM { get; set; }

        public static DB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1 Execute(DB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1 dB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1)
        {
            var ths = dB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB114_ACESSA_MOEDAS_COTACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOEDACOT_VAL_COMPRA = result[i++].Value?.ToString();
            return dta;
        }

    }
}