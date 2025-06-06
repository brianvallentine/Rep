using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0133B
{
    public class M_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<M_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_MOEDA_IMP,
            COD_MOEDA_PRM
            INTO
            :ECOD-MOEDA-IMP,
            :ECOD-MOEDA-PRM
            FROM
            SEGUROS.V1ENDOSSO
            WHERE
            NUM_APOLICE = :R-NUM-APOLICE AND
            NRENDOS = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_MOEDA_IMP
							,
											COD_MOEDA_PRM
											FROM
											SEGUROS.V1ENDOSSO
											WHERE
											NUM_APOLICE = '{this.R_NUM_APOLICE}' AND
											NRENDOS = 0";

            return query;
        }
        public string ECOD_MOEDA_IMP { get; set; }
        public string ECOD_MOEDA_PRM { get; set; }
        public string R_NUM_APOLICE { get; set; }

        public static M_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1 Execute(M_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1 m_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = m_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_240_000_ACESSA_V1ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.ECOD_MOEDA_IMP = result[i++].Value?.ToString();
            dta.ECOD_MOEDA_PRM = result[i++].Value?.ToString();
            return dta;
        }

    }
}