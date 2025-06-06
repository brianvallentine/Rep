using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1 : QueryBasis<M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1>
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
            END-EXEC.
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

        public static M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1 Execute(M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1 m_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1)
        {
            var ths = m_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_10_Query1();
            var i = 0;
            dta.MOEDACOT_VAL_COMPRA = result[i++].Value?.ToString();
            return dta;
        }

    }
}