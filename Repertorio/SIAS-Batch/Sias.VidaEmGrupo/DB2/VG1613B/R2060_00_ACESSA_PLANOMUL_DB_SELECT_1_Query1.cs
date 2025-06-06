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
    public class R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1 : QueryBasis<R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT QTD_SAL_MORNATU,
            QTD_SAL_MORACID,
            QTD_SAL_INVPERM,
            LIM_CAP_MORNATU,
            LIM_CAP_MORACID,
            LIM_CAP_INVAPER
            INTO :PLANOMUL-QTD-SAL-MORNATU,
            :PLANOMUL-QTD-SAL-MORACID,
            :PLANOMUL-QTD-SAL-INVPERM,
            :PLANOMUL-LIM-CAP-MORNATU,
            :PLANOMUL-LIM-CAP-MORACID,
            :PLANOMUL-LIM-CAP-INVAPER
            FROM SEGUROS.PLANOS_MULTISAL
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            AND COD_PLANO = :PLANOVGA-COD-PLANO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT QTD_SAL_MORNATU
							,
											QTD_SAL_MORACID
							,
											QTD_SAL_INVPERM
							,
											LIM_CAP_MORNATU
							,
											LIM_CAP_MORACID
							,
											LIM_CAP_INVAPER
											FROM SEGUROS.PLANOS_MULTISAL
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											AND COD_PLANO = '{this.PLANOVGA_COD_PLANO}'
											WITH UR";

            return query;
        }
        public string PLANOMUL_QTD_SAL_MORNATU { get; set; }
        public string PLANOMUL_QTD_SAL_MORACID { get; set; }
        public string PLANOMUL_QTD_SAL_INVPERM { get; set; }
        public string PLANOMUL_LIM_CAP_MORNATU { get; set; }
        public string PLANOMUL_LIM_CAP_MORACID { get; set; }
        public string PLANOMUL_LIM_CAP_INVAPER { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }
        public string PLANOVGA_COD_PLANO { get; set; }

        public static R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1 Execute(R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1 r2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1)
        {
            var ths = r2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2060_00_ACESSA_PLANOMUL_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLANOMUL_QTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.PLANOMUL_QTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.PLANOMUL_QTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.PLANOMUL_LIM_CAP_MORNATU = result[i++].Value?.ToString();
            dta.PLANOMUL_LIM_CAP_MORACID = result[i++].Value?.ToString();
            dta.PLANOMUL_LIM_CAP_INVAPER = result[i++].Value?.ToString();
            return dta;
        }

    }
}