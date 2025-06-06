using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_600_000_GERA_TERVIG_DB_SELECT_1_Query1 : QueryBasis<M_600_000_GERA_TERVIG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_PROPOSTA + COD_PLANO MONTHS
            INTO :WK-DATA-TERVIG
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE
            NUM_PROPOSTA_SIVPF = :MNUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_PROPOSTA + COD_PLANO MONTHS
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE
											NUM_PROPOSTA_SIVPF = '{this.MNUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string WK_DATA_TERVIG { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static M_600_000_GERA_TERVIG_DB_SELECT_1_Query1 Execute(M_600_000_GERA_TERVIG_DB_SELECT_1_Query1 m_600_000_GERA_TERVIG_DB_SELECT_1_Query1)
        {
            var ths = m_600_000_GERA_TERVIG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_600_000_GERA_TERVIG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_600_000_GERA_TERVIG_DB_SELECT_1_Query1();
            var i = 0;
            dta.WK_DATA_TERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}