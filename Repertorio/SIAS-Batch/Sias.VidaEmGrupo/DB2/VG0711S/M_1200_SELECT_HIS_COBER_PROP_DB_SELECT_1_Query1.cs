using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1 : QueryBasis<M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(QTMDIT, 15),
            VALUE(IMPSEGCDG, 0)
            INTO :HISCOBPR-QTMDIT,
            :HISCOBPR-IMPSEGCDG
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO
            AND DATA_INIVIGENCIA <= CURRENT DATE
            AND DATA_TERVIGENCIA >= CURRENT DATE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(QTMDIT
							, 15)
							,
											VALUE(IMPSEGCDG
							, 0)
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.WS_NUM_CERTIFICADO}'
											AND DATA_INIVIGENCIA <= CURRENT DATE
											AND DATA_TERVIGENCIA >= CURRENT DATE
											WITH UR";

            return query;
        }
        public string HISCOBPR_QTMDIT { get; set; }
        public string HISCOBPR_IMPSEGCDG { get; set; }
        public string WS_NUM_CERTIFICADO { get; set; }

        public static M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1 Execute(M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1 m_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1)
        {
            var ths = m_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1200_SELECT_HIS_COBER_PROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_QTMDIT = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGCDG = result[i++].Value?.ToString();
            return dta;
        }

    }
}