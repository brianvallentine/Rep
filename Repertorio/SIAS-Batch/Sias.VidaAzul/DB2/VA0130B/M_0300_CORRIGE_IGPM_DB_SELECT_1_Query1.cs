using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1 : QueryBasis<M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROPAUTOM
            INTO :FONTE-PROPAUTOM
            FROM SEGUROS.V0FONTE
            WHERE FONTE = :PROPVA-FONTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PROPAUTOM
											FROM SEGUROS.V0FONTE
											WHERE FONTE = '{this.PROPVA_FONTE}'
											WITH UR";

            return query;
        }
        public string FONTE_PROPAUTOM { get; set; }
        public string PROPVA_FONTE { get; set; }

        public static M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1 Execute(M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1 m_0300_CORRIGE_IGPM_DB_SELECT_1_Query1)
        {
            var ths = m_0300_CORRIGE_IGPM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0300_CORRIGE_IGPM_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTE_PROPAUTOM = result[i++].Value?.ToString();
            return dta;
        }

    }
}