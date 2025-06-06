using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1705B
{
    public class M_1500_PROC_FATURAS_DB_SELECT_8_Query1 : QueryBasis<M_1500_PROC_FATURAS_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            PERI_FATURAMENTO ,
            COD_CLIENTE ,
            COD_PAG_ANGARIACAO
            INTO
            :SUBGVGAP-PERI-FATURAMENTO ,
            :SUBGVGAP-COD-CLIENTE ,
            :SUBGVGAP-COD-PAG-ANGARIACAO
            FROM
            SEGUROS.SUBGRUPOS_VGAP
            WHERE
            NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PERI_FATURAMENTO 
							,
											COD_CLIENTE 
							,
											COD_PAG_ANGARIACAO
											FROM
											SEGUROS.SUBGRUPOS_VGAP
											WHERE
											NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'";

            return query;
        }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }
        public string SUBGVGAP_COD_PAG_ANGARIACAO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static M_1500_PROC_FATURAS_DB_SELECT_8_Query1 Execute(M_1500_PROC_FATURAS_DB_SELECT_8_Query1 m_1500_PROC_FATURAS_DB_SELECT_8_Query1)
        {
            var ths = m_1500_PROC_FATURAS_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1500_PROC_FATURAS_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1500_PROC_FATURAS_DB_SELECT_8_Query1();
            var i = 0;
            dta.SUBGVGAP_PERI_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_PAG_ANGARIACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}