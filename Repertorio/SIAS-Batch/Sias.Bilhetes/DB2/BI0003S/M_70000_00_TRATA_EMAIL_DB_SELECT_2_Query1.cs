using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0003S
{
    public class M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1 : QueryBasis<M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT EMAIL
            INTO :DCLPESSOA-EMAIL.EMAIL
            FROM SEGUROS.PESSOA_EMAIL
            WHERE COD_PESSOA = :WS-COD-PES-ATU
            AND SEQ_EMAIL = :WS-MAX-SEQ-EMA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT EMAIL
											FROM SEGUROS.PESSOA_EMAIL
											WHERE COD_PESSOA = '{this.WS_COD_PES_ATU}'
											AND SEQ_EMAIL = '{this.WS_MAX_SEQ_EMA}'
											WITH UR";

            return query;
        }
        public string EMAIL { get; set; }
        public string WS_COD_PES_ATU { get; set; }
        public string WS_MAX_SEQ_EMA { get; set; }

        public static M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1 Execute(M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1 m_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1)
        {
            var ths = m_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1();
            var i = 0;
            dta.EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}