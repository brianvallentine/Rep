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
    public class R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1 : QueryBasis<R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            PRM_VG,
            PRM_AP,
            FAIXA
            INTO
            :PLANFSAL-PRM-VG,
            :PLANFSAL-PRM-AP,
            :PLANFSAL-FAIXA
            FROM SEGUROS.PLANOS_FAIXASAL
            WHERE
            NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            AND COD_PLANO = :PLANOVGA-COD-PLANO
            AND SALARIO_INICIAL <= :PLANFSAL-SALARIO-INICIAL
            AND SALARIO_FINAL >= :PLANFSAL-SALARIO-INICIAL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PRM_VG
							,
											PRM_AP
							,
											FAIXA
											FROM SEGUROS.PLANOS_FAIXASAL
											WHERE
											NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND COD_PLANO = '{this.PLANOVGA_COD_PLANO}'
											AND SALARIO_INICIAL <= '{this.PLANFSAL_SALARIO_INICIAL}'
											AND SALARIO_FINAL >= '{this.PLANFSAL_SALARIO_INICIAL}'
											WITH UR";

            return query;
        }
        public string PLANFSAL_PRM_VG { get; set; }
        public string PLANFSAL_PRM_AP { get; set; }
        public string PLANFSAL_FAIXA { get; set; }
        public string PLANFSAL_SALARIO_INICIAL { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }
        public string PLANOVGA_COD_PLANO { get; set; }

        public static R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1 Execute(R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1 r2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1)
        {
            var ths = r2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2040_00_ACESSA_PLANFSAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLANFSAL_PRM_VG = result[i++].Value?.ToString();
            dta.PLANFSAL_PRM_AP = result[i++].Value?.ToString();
            dta.PLANFSAL_FAIXA = result[i++].Value?.ToString();
            return dta;
        }

    }
}