using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0121B
{
    public class M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1 : QueryBasis<M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            COD_SUBGRUPO,
            COD_CLIENTE
            INTO :SUBGRUPO-NUM-APOL,
            :SUBGRUPO-COD-SUBG,
            :SUBGRUPO-COD-CLI
            FROM SEGUROS.V1SUBGRUPO
            WHERE NUM_APOLICE = :AUX-APOLICE
            AND COD_SUBGRUPO = :AUX-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											COD_CLIENTE
											FROM SEGUROS.V1SUBGRUPO
											WHERE NUM_APOLICE = '{this.AUX_APOLICE}'
											AND COD_SUBGRUPO = '{this.AUX_SUBGRUPO}'";

            return query;
        }
        public string SUBGRUPO_NUM_APOL { get; set; }
        public string SUBGRUPO_COD_SUBG { get; set; }
        public string SUBGRUPO_COD_CLI { get; set; }
        public string AUX_SUBGRUPO { get; set; }
        public string AUX_APOLICE { get; set; }

        public static M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1 Execute(M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1 m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1)
        {
            var ths = m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGRUPO_NUM_APOL = result[i++].Value?.ToString();
            dta.SUBGRUPO_COD_SUBG = result[i++].Value?.ToString();
            dta.SUBGRUPO_COD_CLI = result[i++].Value?.ToString();
            return dta;
        }

    }
}