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
    public class M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1 : QueryBasis<M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            AGE_RCAP
            INTO
            :ENDOSSOS-AGE-PRODUTORA
            FROM
            SEGUROS.ENDOSSOS
            WHERE
            NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											AGE_RCAP
											FROM
											SEGUROS.ENDOSSOS
											WHERE
											NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'";

            return query;
        }
        public string ENDOSSOS_AGE_PRODUTORA { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1 Execute(M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1 m_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1)
        {
            var ths = m_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_EVENTO_DB_SELECT_2_Query1();
            var i = 0;
            dta.ENDOSSOS_AGE_PRODUTORA = result[i++].Value?.ToString();
            return dta;
        }

    }
}