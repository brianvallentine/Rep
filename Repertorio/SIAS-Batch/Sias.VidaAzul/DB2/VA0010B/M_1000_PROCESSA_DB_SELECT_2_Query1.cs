using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_1000_PROCESSA_DB_SELECT_2_Query1 : QueryBasis<M_1000_PROCESSA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT AGENCIA,
            DIA_DEBITO
            INTO :V0PROPAZ-AGENCIA,
            :V0PROPAZ-DIA-DEBITO
            FROM SEGUROS.V0PROPAZUL
            WHERE NRCERTIF = :V1SEGV-NRCERTIF
            AND SITUACAO NOT IN ( '0' , '5' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT AGENCIA
							,
											DIA_DEBITO
											FROM SEGUROS.V0PROPAZUL
											WHERE NRCERTIF = '{this.V1SEGV_NRCERTIF}'
											AND SITUACAO NOT IN ( '0' 
							, '5' )";

            return query;
        }
        public string V0PROPAZ_AGENCIA { get; set; }
        public string V0PROPAZ_DIA_DEBITO { get; set; }
        public string V1SEGV_NRCERTIF { get; set; }

        public static M_1000_PROCESSA_DB_SELECT_2_Query1 Execute(M_1000_PROCESSA_DB_SELECT_2_Query1 m_1000_PROCESSA_DB_SELECT_2_Query1)
        {
            var ths = m_1000_PROCESSA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0PROPAZ_AGENCIA = result[i++].Value?.ToString();
            dta.V0PROPAZ_DIA_DEBITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}