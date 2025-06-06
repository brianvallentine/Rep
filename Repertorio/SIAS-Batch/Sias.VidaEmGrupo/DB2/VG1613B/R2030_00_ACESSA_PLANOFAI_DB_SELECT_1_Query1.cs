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
    public class R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1 : QueryBasis<R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1>
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
            :PLANOFAI-PRM-VG,
            :PLANOFAI-PRM-AP,
            :PLANOFAI-FAIXA
            FROM SEGUROS.PLANOS_FAIXAETA
            WHERE
            NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            AND COD_PLANO = :PLANOVGA-COD-PLANO
            AND IDADE_INICIAL <= :PLANOFAI-IDADE-INICIAL
            AND IDADE_FINAL >= :PLANOFAI-IDADE-INICIAL
            AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO
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
											FROM SEGUROS.PLANOS_FAIXAETA
											WHERE
											NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND COD_PLANO = '{this.PLANOVGA_COD_PLANO}'
											AND IDADE_INICIAL <= '{this.PLANOFAI_IDADE_INICIAL}'
											AND IDADE_FINAL >= '{this.PLANOFAI_IDADE_INICIAL}'
											AND DATA_TERVIGENCIA >= '{this.SISTEMAS_DATA_MOV_ABERTO}'
											WITH UR";

            return query;
        }
        public string PLANOFAI_PRM_VG { get; set; }
        public string PLANOFAI_PRM_AP { get; set; }
        public string PLANOFAI_FAIXA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string PLANOFAI_IDADE_INICIAL { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }
        public string PLANOVGA_COD_PLANO { get; set; }

        public static R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1 Execute(R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1 r2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1)
        {
            var ths = r2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2030_00_ACESSA_PLANOFAI_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLANOFAI_PRM_VG = result[i++].Value?.ToString();
            dta.PLANOFAI_PRM_AP = result[i++].Value?.ToString();
            dta.PLANOFAI_FAIXA = result[i++].Value?.ToString();
            return dta;
        }

    }
}