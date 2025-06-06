using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1 : QueryBasis<M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:PROPVA-DTQITBCO) + 5 DAYS
            INTO :W03-VENCIMENTO
            FROM SEGUROS.V0SISTEMA
            WHERE IDSISTEM = 'VA'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.PROPVA_DTQITBCO}') + 5 DAYS
											FROM SEGUROS.V0SISTEMA
											WHERE IDSISTEM = 'VA'
											WITH UR";

            return query;
        }
        public string W03_VENCIMENTO { get; set; }
        public string PROPVA_DTQITBCO { get; set; }

        public static M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1 Execute(M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1 m_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1)
        {
            var ths = m_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1();
            var i = 0;
            dta.W03_VENCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}