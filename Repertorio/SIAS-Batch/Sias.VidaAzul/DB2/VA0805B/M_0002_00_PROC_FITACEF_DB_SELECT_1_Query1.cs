using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0805B
{
    public class M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1 : QueryBasis<M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_CONVENIO
            INTO :WHOST-NOME-CONVENIO
            FROM SEGUROS.V0CONVSUCOV
            WHERE COD_CONVENIO = :WHOST-COD-CONVENIO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_CONVENIO
											FROM SEGUROS.V0CONVSUCOV
											WHERE COD_CONVENIO = '{this.WHOST_COD_CONVENIO}'
											WITH UR";

            return query;
        }
        public string WHOST_NOME_CONVENIO { get; set; }
        public string WHOST_COD_CONVENIO { get; set; }

        public static M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1 Execute(M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1 m_0002_00_PROC_FITACEF_DB_SELECT_1_Query1)
        {
            var ths = m_0002_00_PROC_FITACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0002_00_PROC_FITACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_NOME_CONVENIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}