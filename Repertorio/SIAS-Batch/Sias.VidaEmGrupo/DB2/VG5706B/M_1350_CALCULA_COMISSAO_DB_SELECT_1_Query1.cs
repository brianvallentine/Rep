using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG5706B
{
    public class M_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1 : QueryBasis<M_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :SQL-PAGAS
            FROM
            SEGUROS.V0PARCELVA
            WHERE
            NRCERTIF = :SQL-NUM-CERT AND
            SITUACAO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM
											SEGUROS.V0PARCELVA
											WHERE
											NRCERTIF = '{this.SQL_NUM_CERT}' AND
											SITUACAO = '1'";

            return query;
        }
        public string SQL_PAGAS { get; set; }
        public string SQL_NUM_CERT { get; set; }

        public static M_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1 Execute(M_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1 m_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1)
        {
            var ths = m_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1350_CALCULA_COMISSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SQL_PAGAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}