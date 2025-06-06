using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1473B
{
    public class M_0110_FETCH_DB_SELECT_1_Query1 : QueryBasis<M_0110_FETCH_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :SUBGVGAP-SIT-REGISTRO
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_SIT_REGISTRO { get; set; }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static M_0110_FETCH_DB_SELECT_1_Query1 Execute(M_0110_FETCH_DB_SELECT_1_Query1 m_0110_FETCH_DB_SELECT_1_Query1)
        {
            var ths = m_0110_FETCH_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0110_FETCH_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0110_FETCH_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}