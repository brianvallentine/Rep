using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9020S
{
    public class M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1 : QueryBasis<M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IDADE,
            CAP_MN_ANT
            INTO :V0MLD-IDADE,
            :V0MLD-CAP-MN-ANT
            FROM SEGUROS.V0MLDTRDAZ
            WHERE
            NUM_CERTIFICADO = :MNUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IDADE
							,
											CAP_MN_ANT
											FROM SEGUROS.V0MLDTRDAZ
											WHERE
											NUM_CERTIFICADO = '{this.MNUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string V0MLD_IDADE { get; set; }
        public string V0MLD_CAP_MN_ANT { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1 Execute(M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1 m_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1)
        {
            var ths = m_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0MLD_IDADE = result[i++].Value?.ToString();
            dta.V0MLD_CAP_MN_ANT = result[i++].Value?.ToString();
            return dta;
        }

    }
}