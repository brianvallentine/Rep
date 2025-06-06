using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1 : QueryBasis<M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_PLANO,
            PERI_FATURAMENTO,
            PERI_RENOVACAO
            INTO :SUBGVGAP-TIPO-PLANO,
            :SUBGVGAP-PERI-FATURAMENTO,
            :SUBGVGAP-PERI-RENOVACAO
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPVA-CODSUBES
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_PLANO
							,
											PERI_FATURAMENTO
							,
											PERI_RENOVACAO
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPVA_CODSUBES}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string SUBGVGAP_TIPO_PLANO { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string SUBGVGAP_PERI_RENOVACAO { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }

        public static M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1 Execute(M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1 m_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1)
        {
            var ths = m_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3400_SELECT_SUBGRUPOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_TIPO_PLANO = result[i++].Value?.ToString();
            dta.SUBGVGAP_PERI_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_PERI_RENOVACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}