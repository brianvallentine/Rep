using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0152B
{
    public class M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1 : QueryBasis<M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODPRODU
            INTO :CODPRODU
            FROM SEGUROS.V0FUNDOCOMISVA
            WHERE NRCERTIF = :NRCERTIF
            AND CODOPER = 1103
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODPRODU
											FROM SEGUROS.V0FUNDOCOMISVA
											WHERE NRCERTIF = '{this.NRCERTIF}'
											AND CODOPER = 1103";

            return query;
        }
        public string CODPRODU { get; set; }
        public string NRCERTIF { get; set; }

        public static M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1 Execute(M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1 m_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1)
        {
            var ths = m_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1500_ESTORNA_FUNDO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CODPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}