using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1 : QueryBasis<R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(FAIXA, 0),
            VALUE(TAXA_VG, 0)
            INTO :FAIXASAL-FAIXA,
            :FAIXASAL-TAXA-VG
            FROM SEGUROS.FAIXA_SALARIAL
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            AND FAIXA =
            (SELECT MIN(A.FAIXA)
            FROM SEGUROS.FAIXA_SALARIAL A
            WHERE A.NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND A.COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(FAIXA
							, 0)
							,
											VALUE(TAXA_VG
							, 0)
											FROM SEGUROS.FAIXA_SALARIAL
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND FAIXA =
											(SELECT MIN(A.FAIXA)
											FROM SEGUROS.FAIXA_SALARIAL A
											WHERE A.NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND A.COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}')
											WITH UR";

            return query;
        }
        public string FAIXASAL_FAIXA { get; set; }
        public string FAIXASAL_TAXA_VG { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1 Execute(R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1 r2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1)
        {
            var ths = r2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.FAIXASAL_FAIXA = result[i++].Value?.ToString();
            dta.FAIXASAL_TAXA_VG = result[i++].Value?.ToString();
            return dta;
        }

    }
}