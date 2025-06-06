using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0820B
{
    public class M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1 : QueryBasis<M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE( ( DAYS(:V0CRED-DTTERVIG) -
            DAYS(:V0RELA-PERI-INICIAL) ) - 1, 0)
            INTO :W-QTD-DIAS-COMP-TERVIG
            FROM SEGUROS.V1SISTEMA
            WHERE IDSISTEM = 'SI'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE( ( DAYS('{this.V0CRED_DTTERVIG}') -
											DAYS('{this.V0RELA_PERI_INICIAL}') ) - 1
							, 0)
											FROM SEGUROS.V1SISTEMA
											WHERE IDSISTEM = 'SI'";

            return query;
        }
        public string W_QTD_DIAS_COMP_TERVIG { get; set; }
        public string V0RELA_PERI_INICIAL { get; set; }
        public string V0CRED_DTTERVIG { get; set; }

        public static M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1 Execute(M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1 m_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1)
        {
            var ths = m_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_00_CALCULA_SALDO_PREMIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_QTD_DIAS_COMP_TERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}