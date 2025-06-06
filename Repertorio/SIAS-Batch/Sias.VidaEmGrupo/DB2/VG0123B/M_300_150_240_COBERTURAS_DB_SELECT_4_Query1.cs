using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0123B
{
    public class M_300_150_240_COBERTURAS_DB_SELECT_4_Query1 : QueryBasis<M_300_150_240_COBERTURAS_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VLCUSTCAP,
            QTTITCAP
            INTO :COBERPR-VLCUSTCAP,
            :COBERPR-QTTITCAP
            FROM SEGUROS.V0COBERPROPVA
            WHERE NRCERTIF = :SEGURAVG-NUM-CERT
            AND DTTERVIG = '9999-12-31'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											VLCUSTCAP
							,
											QTTITCAP
											FROM SEGUROS.V0COBERPROPVA
											WHERE NRCERTIF = '{this.SEGURAVG_NUM_CERT}'
											AND DTTERVIG = '9999-12-31'";

            return query;
        }
        public string COBERPR_VLCUSTCAP { get; set; }
        public string COBERPR_QTTITCAP { get; set; }
        public string SEGURAVG_NUM_CERT { get; set; }

        public static M_300_150_240_COBERTURAS_DB_SELECT_4_Query1 Execute(M_300_150_240_COBERTURAS_DB_SELECT_4_Query1 m_300_150_240_COBERTURAS_DB_SELECT_4_Query1)
        {
            var ths = m_300_150_240_COBERTURAS_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_300_150_240_COBERTURAS_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_300_150_240_COBERTURAS_DB_SELECT_4_Query1();
            var i = 0;
            dta.COBERPR_VLCUSTCAP = result[i++].Value?.ToString();
            dta.COBERPR_QTTITCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}